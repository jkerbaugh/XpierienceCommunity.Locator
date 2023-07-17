export interface LocatorWindow extends Window {
    locator: ILocator;
}

export interface ILocatorSettings {
    apiKey: string;
    apiVersion: string;
    mapPosition: google.maps.LatLng | google.maps.LatLngLiteral;
}

export interface IMapFunctions {
    setMapCenter(latLng: google.maps.LatLng | google.maps.LatLngLiteral): void;
    submitFilter(e: Event): void;
}

export interface ILocator {
    settings: ILocatorSettings,
    map: IMapFunctions
}

export class LocatorApplication {
    private _map: google.maps.Map;
    private _mapPosition: google.maps.LatLng | google.maps.LatLngLiteral;
    private _home: google.maps.Marker;
    private _autocomplete: google.maps.places.Autocomplete;

    private _form: HTMLFormElement;
    private _autocompleteElm: HTMLInputElement;
    private _generalErrorContainer: HTMLElement;

    constructor(locator: ILocator) {
        this._mapPosition = locator.settings.mapPosition;

        this._form = document.querySelector(`form[data-locator-form]`);
        this._autocompleteElm = document.querySelector(`input[data-locator-autocomplete]`);
        this._generalErrorContainer = document.querySelector(`span[data-valmsg-for='GeolocationError']`);

        locator.map = <IMapFunctions>{
            submitFilter: this.applyFilter
        }

        this._form.addEventListener("submit", (e) => this.applyFilter(e));
    }

    async init() {
        await this._setupMap();
        await this._setupAutoComplete();   
    }

    

    setMapCenter(latLng: google.maps.LatLng | google.maps.LatLngLiteral): void {
        this._map.setCenter(latLng);
    }

    applyFilter(event: Event) {
        event.preventDefault();

        var form = <HTMLFormElement>event.target;
        var formData = new FormData(form);
        formData.append("Position.Lat", this._home.getPosition().lat().toString())
        formData.append("Position.Lng", this._home.getPosition().lng().toString())

        fetch(form.action, {
            method: form.method,
            body: formData
        })
            .then(resp => resp.text())
            .then(resp => {
                var replaceTarget = form.getAttribute("data-locator-ajax-update");

                document.querySelector(replaceTarget).innerHTML = resp;
            });
    }

    private async _setupMap() {
        const { Map } = await google.maps.importLibrary("maps") as google.maps.MapsLibrary;

        this._map = new Map(document.getElementById("map") as HTMLElement, {
            center: this._mapPosition,
            zoom: 8,
        });

        this._home = new google.maps.Marker({
            position: this._mapPosition
        });

        this._home.setMap(this._map);
    }

    private async _setupAutoComplete() {
        const { Autocomplete } = await google.maps.importLibrary("places") as google.maps.PlacesLibrary;

        if (this._autocompleteElm) {
            this._autocomplete = new Autocomplete(this._autocompleteElm, {

            });
            this._autocomplete.bindTo("bounds", this._map);

            this._autocomplete.addListener("place_changed", () => {
                this._generalErrorContainer.innerHTML = '';
                this._home.setVisible(false);

                const place = this._autocomplete.getPlace();

                if (!place.geometry || !place.geometry.location) {
                    var node = document.createElement("li");
                    node.textContent = "No details available for input: '" + place.name + "'";
                    this._generalErrorContainer.appendChild(node);

                    return;
                }
                const { location, viewport } = place.geometry;

                if (viewport) {
                    this._map.fitBounds(viewport);
                } else {
                    this._map.setCenter(location);
                    this._map.setZoom(17);
                }

                this._home.setPosition(location);
                this._home.setVisible(true);

            })
        }
    }
}
