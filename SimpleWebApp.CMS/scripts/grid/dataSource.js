"use strict";

function DataSource(options) {
    const self = this;

    options = $.extend({
        items: [],
        columns: [],
        itemsOnPageList: [5]
    }, options);

    self.callback = options.callback || null;
    self.items = ko.observableArray(options.items);
    self.total = ko.observable();
    self.columns = ko.observableArray(options.columns);
    self.itemsOnPageSelected = ko.observable(options.itemsOnPageList[0]);

    self.itemsOnPageSelected.subscribe((newVal) => {
        self.openPage(1);
    });

    self.itemsOnPageList = ko.observableArray(options.itemsOnPageList);
    self.currentPage = ko.observable(1);

    self.pages = ko.computed(() => {
        const p = [];

        for (let i = 1; i <= Math.ceil(self.total() / self.itemsOnPageSelected()) ; i++) {
            p.push(i);
        }

        return p;
    });

    self.openPage = (pageNumber) => {
        const cbresult = self.callback(`/Content/json/articles-page-${pageNumber}.json`);

        cbresult.done((data) => {
            self.items(data.items);
            self.total(data.total);
            self.currentPage(pageNumber);
        });
    };

    self.openPage(1);
}