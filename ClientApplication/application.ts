import { Loader } from "@googlemaps/js-api-loader";
import { LocatorWindow, LocatorApplication } from './models';

declare let window: LocatorWindow;
const locator = window.locator;

const loader = new Loader({
    apiKey: locator.settings.apiKey,
    version: locator.settings.apiVersion,
});

loader.load().then(async () => {
    var app = new LocatorApplication(window.locator);
    app.init();
});
