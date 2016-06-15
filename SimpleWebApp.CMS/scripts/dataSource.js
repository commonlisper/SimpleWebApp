﻿"use strict";

function DataSource(options) {
    var self = this;

    self.items = options.items || ko.observableArray([]);

    self.columns = options.columns || ko.observableArray([]);

    self.itemsOnPage = options.itemsOnPage || 5;

    self.pager = {
        pages: Math.round(self.items().length / self.itemsOnPage),
        currentPage: ko.observable(1)
    };

    self.openPage = function (pageNumber) {
        var selectedItems = articles
            .slice(pageNumber * self.itemsOnPage - self.itemsOnPage, pageNumber * self.itemsOnPage);

        self.items(selectedItems);
        self.pager.currentPage(pageNumber);
    };
}