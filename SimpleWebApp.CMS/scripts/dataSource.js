"use strict";

function DataSource(options) {
    var self = this;

    options = $.extend({
        items: [],
        columns: [],
        itemsOnPageList: [5, 10]
    }, options);

    self.items = ko.observableArray(options.items);

    self.columns = ko.observableArray(options.columns);

    self.itemsOnPageSelected = ko.observable(options.itemsOnPageList[0]);

    self.itemsOnPageList = ko.observableArray(options.itemsOnPageList);

    self.pager = {
        currentPage: ko.observable(1)
    };

    self.openPage = function (pageNumber) {
        var selectedItems = articles
            .slice(pageNumber * self.itemsOnPageSelected() - self.itemsOnPageSelected(), pageNumber * self.itemsOnPageSelected());

        self.items(selectedItems);
        self.pager.currentPage(pageNumber);
    };

    self.computePages = function (sourceCount) {
        return Math.ceil(sourceCount / self.itemsOnPageSelected());
    };
}