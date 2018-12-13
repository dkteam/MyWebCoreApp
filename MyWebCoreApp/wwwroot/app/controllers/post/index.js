var postController = function () {
    this.initialize = function () {
        LoadCategories();
        loadData();
        registerEvents();
    }

    function registerEvents() {
        $('#ddlShowPage').on('change', function () {
            dkteam.configs.pageSize = $(this).val();
            dkteam.configs.pageIndex = 1;
            loadData(true);
        });
        $('#btnSearch').on('click', function () {
            loadData();
        });
        $('#txtKeyword').on('keypress', function (e) {
            if (e.which === 13) {
                loadData();
            }
        });
    }

    function LoadCategories() {
        $.ajax({
            type: 'GET',
            url: '/Admin/Post/GetAllCategory',
            dataType: 'json',
            success: function (response) {
                var render = "<option value=''>---Select category---</option>";
                $.each(response, function (i, item) {
                    render += "<option value = '" + item.Id + "'>" + item.Name + "</option>";
                });
                $('#ddlCategorySearch').html(render);
            },
            error: function (status) {
                console.log(status);
                dkteam.notify('Cannot loading product category data', 'error');
            }
        });
    }

    function loadData(isPageChanged) {
        var template = $('#tblTemplate').html();
        var render = "";
        $.ajax({
            type: 'GET',
            data: {
                categoryId: $('#ddlCategorySearch').val(),
                keyword: $('#txtKeyword').val(),
                page: dkteam.configs.pageIndex,
                pageSize: dkteam.configs.pageSize
            },
            url: '/Admin/Post/GetAllPaging',
            dataType: 'json',
            success: function (res) {
                console.log(res);
                $.each(res.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Name: item.Name,
                        Category: item.PostCategory.Name,
                        CreatedDate: dkteam.dateTimeFormatJson(item.CreatedDate),
                        ModifiedDate: dkteam.dateTimeFormatJson(item.ModifiedDate),
                        ThumbnailImage: item.ThumbnailImage,
                        Views: item.ViewCount,
                        Status: dkteam.getStatus(item.Status)
                    });
                    $('#lblTotalRecords').text(res.RowCount);
                    if (render !== '') {
                        $('#tblContent').html(render);
                    }
                    wrapPaging(res.RowCount, function () {
                        loadData();
                    }, isPageChanged);
                });
            },
            error: function (status) {
                console.log(status);
                dkteam.notify('Cannot loading data', 'error');
            }
        });
    }

    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / dkteam.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp',
            last: 'Cuối',
            onPageClick: function (event, p) {
                dkteam.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }
}