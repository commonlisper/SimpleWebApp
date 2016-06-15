"use strict";

function Article(article) {
    this.id = ko.observable(article.id);
    this.title = ko.observable(article.title);
    this.url = ko.observable(article.url);
    this.description = ko.observable(article.description);
}

var articles = ko.observableArray([
    new Article({
        id: 1,
        title: "Fallot 4",
        url: "fallout4",
        description: "fsffeef werwe, werwer. Erdfsfsf, wetrer rtdgdgddg."
    }),
    new Article({
        id: 2,
        title: "Cats",
        url: "cats",
        description: "fsffeef werwe, werwer. Erdfsfsf, wetrer rtdgdgddg."
    }),
    new Article({
        id: 3,
        title: "Dogs",
        url: "dogs",
        description: "fsffeef werwe, werwer. Erdfsfsf, wetrer rtdgdgddg."
    }),
    new Article({
        id: 4,
        title: "Birds",
        url: "birds",
        description: "fsffeef werwe, werwer. Erdfsfsf, wetrer rtdgdgddg."
    }),
    new Article({
        id: 5,
        title: "Fallot 4",
        url: "fallout4",
        description: "fsffeef werwe, werwer. Erdfsfsf, wetrer rtdgdgddg."
    }),
    new Article({
        id: 6,
        title: "Cats",
        url: "cats",
        description: "fsffeef werwe, werwer. Erdfsfsf, wetrer rtdgdgddg."
    }),
    new Article({
        id: 7,
        title: "Dogs",
        url: "dogs",
        description: "fsffeef werwe, werwer. Erdfsfsf, wetrer rtdgdgddg."
    }),
    new Article({
        id: 8,
        title: "Birds",
        url: "birds",
        description: "fsffeef werwe, werwer. Erdfsfsf, wetrer rtdgdgddg."
    }),
    new Article({
        id: 9,
        title: "Fallot 4",
        url: "fallout4",
        description: "fsffeef werwe, werwer. Erdfsfsf, wetrer rtdgdgddg."
    }),
    new Article({
        id: 10,
        title: "Cats",
        url: "cats",
        description: "fsffeef werwe, werwer. Erdfsfsf, wetrer rtdgdgddg."
    }),
    new Article({
        id: 11,
        title: "Dogs",
        url: "dogs",
        description: "fsffeef werwe, werwer. Erdfsfsf, wetrer rtdgdgddg."
    }),
    new Article({
        id: 12,
        title: "Birds",
        url: "birds",
        description: "fsffeef werwe, werwer. Erdfsfsf, wetrer rtdgdgddg."
    })
]);