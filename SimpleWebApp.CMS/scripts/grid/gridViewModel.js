"use strict";

function GridViewModel(dataSource) {
    const self = this;

    self.dataSource = dataSource;

    self.actions = {
        showPrevPage: () => {
            const currentPage = self.dataSource.currentPage();
            const nextPage = currentPage <= 1 ? 1 : currentPage - 1;

            self.dataSource.openPage(nextPage);
        },

        showNextPage: () => {
            const currentPage = self.dataSource.currentPage();
            const pagesCount = self.dataSource.pages().length;
            const nextPage = currentPage + 1 >= pagesCount ? pagesCount : currentPage + 1;

            self.dataSource.openPage(nextPage);
        }
    };
}