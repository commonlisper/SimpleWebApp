"use strict";

function DataSource(options) {
    const self = this;

    options = $.extend({
        items: [],
        columns: [],
        itemsOnPageList: [5, 10]
    }, options);

    self.items = ko.observableArray(options.items);
    self.total = ko.observable();
    self.columns = ko.observableArray(options.columns);
    self.itemsOnPageSelected = ko.observable(options.itemsOnPageList[0]);
    self.itemsOnPageList = ko.observableArray(options.itemsOnPageList);
    self.currentPage = ko.observable(1);

    self.openPage = (pageNumber) => {
        const get = $.getJSON("/Content/json/articles.json");

        get.done((data) => {
            const selectedItems = data.slice(pageNumber * self.itemsOnPageSelected() - self.itemsOnPageSelected(),
                pageNumber * self.itemsOnPageSelected());

            self.total(data.length);
            self.items(selectedItems);
        });

        self.currentPage(pageNumber);
    };

    self.computePages = (sourceCount) => {
        return Math.ceil(sourceCount / self.itemsOnPageSelected());
    };
}