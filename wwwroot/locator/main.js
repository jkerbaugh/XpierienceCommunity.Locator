/*
 * ATTENTION: The "eval" devtool has been used (maybe by default in mode: "development").
 * This devtool is neither made for production nor for readable output files.
 * It uses "eval()" calls to create a separate source file in the browser devtools.
 * If you are trying to read the output file, select a different devtool (https://webpack.js.org/configuration/devtool/)
 * or disable the default devtool with "devtool: false".
 * If you are looking for production-ready output files, see mode: "production" (https://webpack.js.org/configuration/mode/).
 */
/******/ (() => { // webpackBootstrap
/******/ 	"use strict";
/******/ 	var __webpack_modules__ = ({

/***/ "./node_modules/@googlemaps/js-api-loader/dist/index.esm.js":
/*!******************************************************************!*\
  !*** ./node_modules/@googlemaps/js-api-loader/dist/index.esm.js ***!
  \******************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export */ __webpack_require__.d(__webpack_exports__, {\n/* harmony export */   DEFAULT_ID: () => (/* binding */ DEFAULT_ID),\n/* harmony export */   Loader: () => (/* binding */ Loader),\n/* harmony export */   LoaderStatus: () => (/* binding */ LoaderStatus)\n/* harmony export */ });\n/*! *****************************************************************************\r\nCopyright (c) Microsoft Corporation.\r\n\r\nPermission to use, copy, modify, and/or distribute this software for any\r\npurpose with or without fee is hereby granted.\r\n\r\nTHE SOFTWARE IS PROVIDED \"AS IS\" AND THE AUTHOR DISCLAIMS ALL WARRANTIES WITH\r\nREGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF MERCHANTABILITY\r\nAND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL, DIRECT,\r\nINDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES WHATSOEVER RESULTING FROM\r\nLOSS OF USE, DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR\r\nOTHER TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR\r\nPERFORMANCE OF THIS SOFTWARE.\r\n***************************************************************************** */\r\n\r\nfunction __awaiter(thisArg, _arguments, P, generator) {\r\n    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }\r\n    return new (P || (P = Promise))(function (resolve, reject) {\r\n        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }\r\n        function rejected(value) { try { step(generator[\"throw\"](value)); } catch (e) { reject(e); } }\r\n        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }\r\n        step((generator = generator.apply(thisArg, _arguments || [])).next());\r\n    });\r\n}\n\n// do not edit .js files directly - edit src/index.jst\n\n\n\nvar fastDeepEqual = function equal(a, b) {\n  if (a === b) return true;\n\n  if (a && b && typeof a == 'object' && typeof b == 'object') {\n    if (a.constructor !== b.constructor) return false;\n\n    var length, i, keys;\n    if (Array.isArray(a)) {\n      length = a.length;\n      if (length != b.length) return false;\n      for (i = length; i-- !== 0;)\n        if (!equal(a[i], b[i])) return false;\n      return true;\n    }\n\n\n\n    if (a.constructor === RegExp) return a.source === b.source && a.flags === b.flags;\n    if (a.valueOf !== Object.prototype.valueOf) return a.valueOf() === b.valueOf();\n    if (a.toString !== Object.prototype.toString) return a.toString() === b.toString();\n\n    keys = Object.keys(a);\n    length = keys.length;\n    if (length !== Object.keys(b).length) return false;\n\n    for (i = length; i-- !== 0;)\n      if (!Object.prototype.hasOwnProperty.call(b, keys[i])) return false;\n\n    for (i = length; i-- !== 0;) {\n      var key = keys[i];\n\n      if (!equal(a[key], b[key])) return false;\n    }\n\n    return true;\n  }\n\n  // true if both NaN, false otherwise\n  return a!==a && b!==b;\n};\n\n/**\n * Copyright 2019 Google LLC. All Rights Reserved.\n *\n * Licensed under the Apache License, Version 2.0 (the \"License\");\n * you may not use this file except in compliance with the License.\n * You may obtain a copy of the License at.\n *\n *      Http://www.apache.org/licenses/LICENSE-2.0.\n *\n * Unless required by applicable law or agreed to in writing, software\n * distributed under the License is distributed on an \"AS IS\" BASIS,\n * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.\n * See the License for the specific language governing permissions and\n * limitations under the License.\n */\nconst DEFAULT_ID = \"__googleMapsScriptId\";\n/**\n * The status of the [[Loader]].\n */\nvar LoaderStatus;\n(function (LoaderStatus) {\n    LoaderStatus[LoaderStatus[\"INITIALIZED\"] = 0] = \"INITIALIZED\";\n    LoaderStatus[LoaderStatus[\"LOADING\"] = 1] = \"LOADING\";\n    LoaderStatus[LoaderStatus[\"SUCCESS\"] = 2] = \"SUCCESS\";\n    LoaderStatus[LoaderStatus[\"FAILURE\"] = 3] = \"FAILURE\";\n})(LoaderStatus || (LoaderStatus = {}));\n/**\n * [[Loader]] makes it easier to add Google Maps JavaScript API to your application\n * dynamically using\n * [Promises](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Promise).\n * It works by dynamically creating and appending a script node to the the\n * document head and wrapping the callback function so as to return a promise.\n *\n * ```\n * const loader = new Loader({\n *   apiKey: \"\",\n *   version: \"weekly\",\n *   libraries: [\"places\"]\n * });\n *\n * loader.load().then((google) => {\n *   const map = new google.maps.Map(...)\n * })\n * ```\n */\nclass Loader {\n    /**\n     * Creates an instance of Loader using [[LoaderOptions]]. No defaults are set\n     * using this library, instead the defaults are set by the Google Maps\n     * JavaScript API server.\n     *\n     * ```\n     * const loader = Loader({apiKey, version: 'weekly', libraries: ['places']});\n     * ```\n     */\n    constructor({ apiKey, authReferrerPolicy, channel, client, id = DEFAULT_ID, language, libraries = [], mapIds, nonce, region, retries = 3, url = \"https://maps.googleapis.com/maps/api/js\", version, }) {\n        this.callbacks = [];\n        this.done = false;\n        this.loading = false;\n        this.errors = [];\n        this.apiKey = apiKey;\n        this.authReferrerPolicy = authReferrerPolicy;\n        this.channel = channel;\n        this.client = client;\n        this.id = id || DEFAULT_ID; // Do not allow empty string\n        this.language = language;\n        this.libraries = libraries;\n        this.mapIds = mapIds;\n        this.nonce = nonce;\n        this.region = region;\n        this.retries = retries;\n        this.url = url;\n        this.version = version;\n        if (Loader.instance) {\n            if (!fastDeepEqual(this.options, Loader.instance.options)) {\n                throw new Error(`Loader must not be called again with different options. ${JSON.stringify(this.options)} !== ${JSON.stringify(Loader.instance.options)}`);\n            }\n            return Loader.instance;\n        }\n        Loader.instance = this;\n    }\n    get options() {\n        return {\n            version: this.version,\n            apiKey: this.apiKey,\n            channel: this.channel,\n            client: this.client,\n            id: this.id,\n            libraries: this.libraries,\n            language: this.language,\n            region: this.region,\n            mapIds: this.mapIds,\n            nonce: this.nonce,\n            url: this.url,\n            authReferrerPolicy: this.authReferrerPolicy,\n        };\n    }\n    get status() {\n        if (this.errors.length) {\n            return LoaderStatus.FAILURE;\n        }\n        if (this.done) {\n            return LoaderStatus.SUCCESS;\n        }\n        if (this.loading) {\n            return LoaderStatus.LOADING;\n        }\n        return LoaderStatus.INITIALIZED;\n    }\n    get failed() {\n        return this.done && !this.loading && this.errors.length >= this.retries + 1;\n    }\n    /**\n     * CreateUrl returns the Google Maps JavaScript API script url given the [[LoaderOptions]].\n     *\n     * @ignore\n     * @deprecated\n     */\n    createUrl() {\n        let url = this.url;\n        url += `?callback=__googleMapsCallback`;\n        if (this.apiKey) {\n            url += `&key=${this.apiKey}`;\n        }\n        if (this.channel) {\n            url += `&channel=${this.channel}`;\n        }\n        if (this.client) {\n            url += `&client=${this.client}`;\n        }\n        if (this.libraries.length > 0) {\n            url += `&libraries=${this.libraries.join(\",\")}`;\n        }\n        if (this.language) {\n            url += `&language=${this.language}`;\n        }\n        if (this.region) {\n            url += `&region=${this.region}`;\n        }\n        if (this.version) {\n            url += `&v=${this.version}`;\n        }\n        if (this.mapIds) {\n            url += `&map_ids=${this.mapIds.join(\",\")}`;\n        }\n        if (this.authReferrerPolicy) {\n            url += `&auth_referrer_policy=${this.authReferrerPolicy}`;\n        }\n        return url;\n    }\n    deleteScript() {\n        const script = document.getElementById(this.id);\n        if (script) {\n            script.remove();\n        }\n    }\n    /**\n     * Load the Google Maps JavaScript API script and return a Promise.\n     * @deprecated, use importLibrary() instead.\n     */\n    load() {\n        return this.loadPromise();\n    }\n    /**\n     * Load the Google Maps JavaScript API script and return a Promise.\n     *\n     * @ignore\n     * @deprecated, use importLibrary() instead.\n     */\n    loadPromise() {\n        return new Promise((resolve, reject) => {\n            this.loadCallback((err) => {\n                if (!err) {\n                    resolve(window.google);\n                }\n                else {\n                    reject(err.error);\n                }\n            });\n        });\n    }\n    importLibrary(name) {\n        this.execute();\n        return google.maps.importLibrary(name);\n    }\n    /**\n     * Load the Google Maps JavaScript API script with a callback.\n     * @deprecated, use importLibrary() instead.\n     */\n    loadCallback(fn) {\n        this.callbacks.push(fn);\n        this.execute();\n    }\n    /**\n     * Set the script on document.\n     */\n    setScript() {\n        var _a, _b;\n        if (document.getElementById(this.id)) {\n            // TODO wrap onerror callback for cases where the script was loaded elsewhere\n            this.callback();\n            return;\n        }\n        const params = {\n            key: this.apiKey,\n            channel: this.channel,\n            client: this.client,\n            libraries: this.libraries.length && this.libraries,\n            v: this.version,\n            mapIds: this.mapIds,\n            language: this.language,\n            region: this.region,\n            authReferrerPolicy: this.authReferrerPolicy,\n        };\n        // keep the URL minimal:\n        Object.keys(params).forEach(\n        // eslint-disable-next-line @typescript-eslint/no-explicit-any\n        (key) => !params[key] && delete params[key]);\n        if (!((_b = (_a = window === null || window === void 0 ? void 0 : window.google) === null || _a === void 0 ? void 0 : _a.maps) === null || _b === void 0 ? void 0 : _b.importLibrary)) {\n            // tweaked copy of https://developers.google.com/maps/documentation/javascript/load-maps-js-api#dynamic-library-import\n            // which also sets the base url, the id, and the nonce\n            /* eslint-disable */\n            ((g) => {\n                // @ts-ignore\n                let h, a, k, p = \"The Google Maps JavaScript API\", c = \"google\", l = \"importLibrary\", q = \"__ib__\", m = document, b = window;\n                // @ts-ignore\n                b = b[c] || (b[c] = {});\n                // @ts-ignore\n                const d = b.maps || (b.maps = {}), r = new Set(), e = new URLSearchParams(), u = () => \n                // @ts-ignore\n                h || (h = new Promise((f, n) => __awaiter(this, void 0, void 0, function* () {\n                    var _a;\n                    yield (a = m.createElement(\"script\"));\n                    a.id = this.id;\n                    e.set(\"libraries\", [...r] + \"\");\n                    // @ts-ignore\n                    for (k in g)\n                        e.set(k.replace(/[A-Z]/g, (t) => \"_\" + t[0].toLowerCase()), g[k]);\n                    e.set(\"callback\", c + \".maps.\" + q);\n                    a.src = this.url + `?` + e;\n                    d[q] = f;\n                    a.onerror = () => (h = n(Error(p + \" could not load.\")));\n                    // @ts-ignore\n                    a.nonce = this.nonce || ((_a = m.querySelector(\"script[nonce]\")) === null || _a === void 0 ? void 0 : _a.nonce) || \"\";\n                    m.head.append(a);\n                })));\n                // @ts-ignore\n                d[l] ? console.warn(p + \" only loads once. Ignoring:\", g) : (d[l] = (f, ...n) => r.add(f) && u().then(() => d[l](f, ...n)));\n            })(params);\n            /* eslint-enable */\n        }\n        // While most libraries populate the global namespace when loaded via bootstrap params,\n        // this is not the case for \"marker\" when used with the inline bootstrap loader\n        // (and maybe others in the future). So ensure there is an importLibrary for each:\n        const libraryPromises = this.libraries.map((library) => this.importLibrary(library));\n        // ensure at least one library, to kick off loading...\n        if (!libraryPromises.length) {\n            libraryPromises.push(this.importLibrary(\"core\"));\n        }\n        Promise.all(libraryPromises).then(() => this.callback(), (error) => {\n            const event = new ErrorEvent(\"error\", { error }); // for backwards compat\n            this.loadErrorCallback(event);\n        });\n    }\n    /**\n     * Reset the loader state.\n     */\n    reset() {\n        this.deleteScript();\n        this.done = false;\n        this.loading = false;\n        this.errors = [];\n        this.onerrorEvent = null;\n    }\n    resetIfRetryingFailed() {\n        if (this.failed) {\n            this.reset();\n        }\n    }\n    loadErrorCallback(e) {\n        this.errors.push(e);\n        if (this.errors.length <= this.retries) {\n            const delay = this.errors.length * Math.pow(2, this.errors.length);\n            console.error(`Failed to load Google Maps script, retrying in ${delay} ms.`);\n            setTimeout(() => {\n                this.deleteScript();\n                this.setScript();\n            }, delay);\n        }\n        else {\n            this.onerrorEvent = e;\n            this.callback();\n        }\n    }\n    callback() {\n        this.done = true;\n        this.loading = false;\n        this.callbacks.forEach((cb) => {\n            cb(this.onerrorEvent);\n        });\n        this.callbacks = [];\n    }\n    execute() {\n        this.resetIfRetryingFailed();\n        if (this.done) {\n            this.callback();\n        }\n        else {\n            // short circuit and warn if google.maps is already loaded\n            if (window.google && window.google.maps && window.google.maps.version) {\n                console.warn(\"Google Maps already loaded outside @googlemaps/js-api-loader.\" +\n                    \"This may result in undesirable behavior as options and script parameters may not match.\");\n                this.callback();\n                return;\n            }\n            if (this.loading) ;\n            else {\n                this.loading = true;\n                this.setScript();\n            }\n        }\n    }\n}\n\n\n//# sourceMappingURL=index.esm.js.map\n\n\n//# sourceURL=webpack://clientapplication/./node_modules/@googlemaps/js-api-loader/dist/index.esm.js?");

/***/ }),

/***/ "./ClientApplication/application.ts":
/*!******************************************!*\
  !*** ./ClientApplication/application.ts ***!
  \******************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

eval("__webpack_require__.r(__webpack_exports__);\n/* harmony import */ var _googlemaps_js_api_loader__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @googlemaps/js-api-loader */ \"./node_modules/@googlemaps/js-api-loader/dist/index.esm.js\");\n/* harmony import */ var _models__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./models */ \"./ClientApplication/models.ts\");\nvar __awaiter = (undefined && undefined.__awaiter) || function (thisArg, _arguments, P, generator) {\r\n    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }\r\n    return new (P || (P = Promise))(function (resolve, reject) {\r\n        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }\r\n        function rejected(value) { try { step(generator[\"throw\"](value)); } catch (e) { reject(e); } }\r\n        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }\r\n        step((generator = generator.apply(thisArg, _arguments || [])).next());\r\n    });\r\n};\r\nvar __generator = (undefined && undefined.__generator) || function (thisArg, body) {\r\n    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;\r\n    return g = { next: verb(0), \"throw\": verb(1), \"return\": verb(2) }, typeof Symbol === \"function\" && (g[Symbol.iterator] = function() { return this; }), g;\r\n    function verb(n) { return function (v) { return step([n, v]); }; }\r\n    function step(op) {\r\n        if (f) throw new TypeError(\"Generator is already executing.\");\r\n        while (g && (g = 0, op[0] && (_ = 0)), _) try {\r\n            if (f = 1, y && (t = op[0] & 2 ? y[\"return\"] : op[0] ? y[\"throw\"] || ((t = y[\"return\"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;\r\n            if (y = 0, t) op = [op[0] & 2, t.value];\r\n            switch (op[0]) {\r\n                case 0: case 1: t = op; break;\r\n                case 4: _.label++; return { value: op[1], done: false };\r\n                case 5: _.label++; y = op[1]; op = [0]; continue;\r\n                case 7: op = _.ops.pop(); _.trys.pop(); continue;\r\n                default:\r\n                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }\r\n                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }\r\n                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }\r\n                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }\r\n                    if (t[2]) _.ops.pop();\r\n                    _.trys.pop(); continue;\r\n            }\r\n            op = body.call(thisArg, _);\r\n        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }\r\n        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };\r\n    }\r\n};\r\n\r\n\r\nvar locator = window.locator;\r\nvar loader = new _googlemaps_js_api_loader__WEBPACK_IMPORTED_MODULE_0__.Loader({\r\n    apiKey: locator.settings.apiKey,\r\n    version: locator.settings.apiVersion,\r\n});\r\nloader.load().then(function () { return __awaiter(void 0, void 0, void 0, function () {\r\n    var app;\r\n    return __generator(this, function (_a) {\r\n        app = new _models__WEBPACK_IMPORTED_MODULE_1__.LocatorApplication(window.locator);\r\n        app.init();\r\n        return [2 /*return*/];\r\n    });\r\n}); });\r\n\n\n//# sourceURL=webpack://clientapplication/./ClientApplication/application.ts?");

/***/ }),

/***/ "./ClientApplication/models.ts":
/*!*************************************!*\
  !*** ./ClientApplication/models.ts ***!
  \*************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export */ __webpack_require__.d(__webpack_exports__, {\n/* harmony export */   LocatorApplication: () => (/* binding */ LocatorApplication)\n/* harmony export */ });\nvar __awaiter = (undefined && undefined.__awaiter) || function (thisArg, _arguments, P, generator) {\r\n    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }\r\n    return new (P || (P = Promise))(function (resolve, reject) {\r\n        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }\r\n        function rejected(value) { try { step(generator[\"throw\"](value)); } catch (e) { reject(e); } }\r\n        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }\r\n        step((generator = generator.apply(thisArg, _arguments || [])).next());\r\n    });\r\n};\r\nvar __generator = (undefined && undefined.__generator) || function (thisArg, body) {\r\n    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;\r\n    return g = { next: verb(0), \"throw\": verb(1), \"return\": verb(2) }, typeof Symbol === \"function\" && (g[Symbol.iterator] = function() { return this; }), g;\r\n    function verb(n) { return function (v) { return step([n, v]); }; }\r\n    function step(op) {\r\n        if (f) throw new TypeError(\"Generator is already executing.\");\r\n        while (g && (g = 0, op[0] && (_ = 0)), _) try {\r\n            if (f = 1, y && (t = op[0] & 2 ? y[\"return\"] : op[0] ? y[\"throw\"] || ((t = y[\"return\"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;\r\n            if (y = 0, t) op = [op[0] & 2, t.value];\r\n            switch (op[0]) {\r\n                case 0: case 1: t = op; break;\r\n                case 4: _.label++; return { value: op[1], done: false };\r\n                case 5: _.label++; y = op[1]; op = [0]; continue;\r\n                case 7: op = _.ops.pop(); _.trys.pop(); continue;\r\n                default:\r\n                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }\r\n                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }\r\n                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }\r\n                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }\r\n                    if (t[2]) _.ops.pop();\r\n                    _.trys.pop(); continue;\r\n            }\r\n            op = body.call(thisArg, _);\r\n        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }\r\n        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };\r\n    }\r\n};\r\nvar LocatorApplication = /** @class */ (function () {\r\n    function LocatorApplication(locator) {\r\n        var _this = this;\r\n        this._mapPosition = locator.settings.mapPosition;\r\n        this._form = document.querySelector(\"form[data-locator-form]\");\r\n        this._autocompleteElm = document.querySelector(\"input[data-locator-autocomplete]\");\r\n        this._generalErrorContainer = document.querySelector(\"span[data-valmsg-for='GeolocationError']\");\r\n        locator.map = {\r\n            submitFilter: this.applyFilter\r\n        };\r\n        this._form.addEventListener(\"submit\", function (e) { return _this.applyFilter(e); });\r\n    }\r\n    LocatorApplication.prototype.init = function () {\r\n        return __awaiter(this, void 0, void 0, function () {\r\n            return __generator(this, function (_a) {\r\n                switch (_a.label) {\r\n                    case 0: return [4 /*yield*/, this._setupMap()];\r\n                    case 1:\r\n                        _a.sent();\r\n                        return [4 /*yield*/, this._setupAutoComplete()];\r\n                    case 2:\r\n                        _a.sent();\r\n                        return [2 /*return*/];\r\n                }\r\n            });\r\n        });\r\n    };\r\n    LocatorApplication.prototype.setMapCenter = function (latLng) {\r\n        this._map.setCenter(latLng);\r\n    };\r\n    LocatorApplication.prototype.applyFilter = function (event) {\r\n        event.preventDefault();\r\n        var form = event.target;\r\n        var formData = new FormData(form);\r\n        formData.append(\"Position.Lat\", this._home.getPosition().lat().toString());\r\n        formData.append(\"Position.Lng\", this._home.getPosition().lng().toString());\r\n        fetch(form.action, {\r\n            method: form.method,\r\n            body: formData\r\n        })\r\n            .then(function (resp) { return resp.text(); })\r\n            .then(function (resp) {\r\n            var replaceTarget = form.getAttribute(\"data-locator-ajax-update\");\r\n            document.querySelector(replaceTarget).innerHTML = resp;\r\n        });\r\n    };\r\n    LocatorApplication.prototype._setupMap = function () {\r\n        return __awaiter(this, void 0, void 0, function () {\r\n            var Map;\r\n            return __generator(this, function (_a) {\r\n                switch (_a.label) {\r\n                    case 0: return [4 /*yield*/, google.maps.importLibrary(\"maps\")];\r\n                    case 1:\r\n                        Map = (_a.sent()).Map;\r\n                        this._map = new Map(document.getElementById(\"map\"), {\r\n                            center: this._mapPosition,\r\n                            zoom: 8,\r\n                        });\r\n                        this._home = new google.maps.Marker({\r\n                            position: this._mapPosition\r\n                        });\r\n                        this._home.setMap(this._map);\r\n                        return [2 /*return*/];\r\n                }\r\n            });\r\n        });\r\n    };\r\n    LocatorApplication.prototype._setupAutoComplete = function () {\r\n        return __awaiter(this, void 0, void 0, function () {\r\n            var Autocomplete;\r\n            var _this = this;\r\n            return __generator(this, function (_a) {\r\n                switch (_a.label) {\r\n                    case 0: return [4 /*yield*/, google.maps.importLibrary(\"places\")];\r\n                    case 1:\r\n                        Autocomplete = (_a.sent()).Autocomplete;\r\n                        if (this._autocompleteElm) {\r\n                            this._autocomplete = new Autocomplete(this._autocompleteElm, {});\r\n                            this._autocomplete.bindTo(\"bounds\", this._map);\r\n                            this._autocomplete.addListener(\"place_changed\", function () {\r\n                                _this._generalErrorContainer.innerHTML = '';\r\n                                _this._home.setVisible(false);\r\n                                var place = _this._autocomplete.getPlace();\r\n                                if (!place.geometry || !place.geometry.location) {\r\n                                    var node = document.createElement(\"li\");\r\n                                    node.textContent = \"No details available for input: '\" + place.name + \"'\";\r\n                                    _this._generalErrorContainer.appendChild(node);\r\n                                    return;\r\n                                }\r\n                                var _a = place.geometry, location = _a.location, viewport = _a.viewport;\r\n                                if (viewport) {\r\n                                    _this._map.fitBounds(viewport);\r\n                                }\r\n                                else {\r\n                                    _this._map.setCenter(location);\r\n                                    _this._map.setZoom(17);\r\n                                }\r\n                                _this._home.setPosition(location);\r\n                                _this._home.setVisible(true);\r\n                            });\r\n                        }\r\n                        return [2 /*return*/];\r\n                }\r\n            });\r\n        });\r\n    };\r\n    return LocatorApplication;\r\n}());\r\n\r\n\n\n//# sourceURL=webpack://clientapplication/./ClientApplication/models.ts?");

/***/ })

/******/ 	});
/************************************************************************/
/******/ 	// The module cache
/******/ 	var __webpack_module_cache__ = {};
/******/ 	
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/ 		// Check if module is in cache
/******/ 		var cachedModule = __webpack_module_cache__[moduleId];
/******/ 		if (cachedModule !== undefined) {
/******/ 			return cachedModule.exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = __webpack_module_cache__[moduleId] = {
/******/ 			// no module.id needed
/******/ 			// no module.loaded needed
/******/ 			exports: {}
/******/ 		};
/******/ 	
/******/ 		// Execute the module function
/******/ 		__webpack_modules__[moduleId](module, module.exports, __webpack_require__);
/******/ 	
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/ 	
/************************************************************************/
/******/ 	/* webpack/runtime/define property getters */
/******/ 	(() => {
/******/ 		// define getter functions for harmony exports
/******/ 		__webpack_require__.d = (exports, definition) => {
/******/ 			for(var key in definition) {
/******/ 				if(__webpack_require__.o(definition, key) && !__webpack_require__.o(exports, key)) {
/******/ 					Object.defineProperty(exports, key, { enumerable: true, get: definition[key] });
/******/ 				}
/******/ 			}
/******/ 		};
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/hasOwnProperty shorthand */
/******/ 	(() => {
/******/ 		__webpack_require__.o = (obj, prop) => (Object.prototype.hasOwnProperty.call(obj, prop))
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/make namespace object */
/******/ 	(() => {
/******/ 		// define __esModule on exports
/******/ 		__webpack_require__.r = (exports) => {
/******/ 			if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 				Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 			}
/******/ 			Object.defineProperty(exports, '__esModule', { value: true });
/******/ 		};
/******/ 	})();
/******/ 	
/************************************************************************/
/******/ 	
/******/ 	// startup
/******/ 	// Load entry module and return exports
/******/ 	// This entry module can't be inlined because the eval devtool is used.
/******/ 	var __webpack_exports__ = __webpack_require__("./ClientApplication/application.ts");
/******/ 	
/******/ })()
;