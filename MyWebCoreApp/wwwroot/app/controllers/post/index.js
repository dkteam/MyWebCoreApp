var postController = function () {
    this.initialize = function () {
        LoadCategories();
        loadData();
        registerEvents();
        registerControls();
    }

    function registerEvents() {
        //Init validation
        $('#frmMaintainance').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'vi',
            rules: {
                txtNameM: { required: true },
                ddlCategoryIdM: { required: true }           
            }
        });

        $('#btnSelectImg').on('click', function () {
            $('#fileInputImage').click();
        });

        $("#fileInputImage").on('change', function () {
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            $.ajax({
                type: "POST",
                url: "/Admin/Upload/UploadImage",
                contentType: false,
                processData: false,
                data: data,
                success: function (path) {
                    $('#txtImageM').val(path);
                    dkteam.notify('Upload image succesful!', 'success');

                },
                error: function () {
                    dkteam.notify('There was error uploading files!', 'error');
                }
            });
        });

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

        $("#btnCreate").on('click', function () {
            resetFormMaintainance();
            initTreeDropDownCategory();
            $('#modal-add-edit').modal('show');
        });

        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            $.ajax({
                type: "GET",
                url: "/Admin/Post/GetById",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    dkteam.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $('#hidIdM').val(data.Id);
                    $('#txtNameM').val(data.Name);
                    initTreeDropDownCategory(data.CategoryId);

                    $('#txtDescM').val(data.Description);
                    //$('#txtUnitM').val(data.Unit);

                    //$('#txtPriceM').val(data.Price);
                    //$('#txtOriginalPriceM').val(data.OriginalPrice);
                    //$('#txtPromotionPriceM').val(data.PromotionPrice);

                    $('#txtImageM').val(data.ThumbnailImage);

                    //$("#txtOrderM").val(data.SortOrder);
                    $('#txtTagM').val(data.Tags);
                    $('#txtMetakeywordM').val(data.SeoKeywords);
                    $('#txtMetaDescriptionM').val(data.SeoDescription);
                    $('#txtSeoPageTitleM').val(data.SeoPageTitle);
                    $('#txtSeoAliasM').val(data.SeoAlias);

                    CKEDITOR.instances.txtContentM.setData(data.Content);
                    $('#ckStatusM').prop('checked', data.Status == 1);
                    //$('#ckHotM').prop('checked', data.HotFlag);
                    $('#ckShowHomeM').prop('checked', data.HomeFlag);

                    $('#modal-add-edit').modal('show');
                    dkteam.stopLoading();

                },
                error: function (status) {
                    dkteam.notify('Có lỗi xảy ra', 'error');
                    dkteam.stopLoading();
                }
            });
        });

        $('body').on('click', '.btn-delete', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            dkteam.confirm('Are you sure to delete?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/Post/Delete",
                    data: { id: that },
                    dataType: "json",
                    beforeSend: function () {
                        dkteam.startLoading();
                    },
                    success: function (response) {
                        dkteam.notify('Delete successful', 'success');
                        dkteam.stopLoading();
                        loadData();
                    },
                    error: function (status) {
                        dkteam.notify('Has an error in delete progress', 'error');
                        dkteam.stopLoading();
                    }
                });
            });
        });

        $('#btnSave').on('click', function (e) {
            if ($('#frmMaintainance').valid()) {
                e.preventDefault();
                var id = parseInt($('#hidIdM').val());
                var name = $('#txtNameM').val();
                var categoryId = $('#ddlCategoryIdM').combotree('getValue');

                var description = $('#txtDescM').val();

                //var unit = $('#txtUnitM').val();
                //var price = $('#txtPriceM').val();
                //var originalPrice = $('#txtOriginalPriceM').val();
                //var promotionPrice = $('#txtPromotionPriceM').val();

                var image = $('#txtImageM').val();

                var tags = $('#txtTagM').val();
                var seoKeyword = $('#txtMetakeywordM').val();
                var seoMetaDescription = $('#txtMetaDescriptionM').val();
                var seoPageTitle = $('#txtSeoPageTitleM').val();
                var seoAlias = $('#txtSeoAliasM').val();

                var content = CKEDITOR.instances.txtContentM.getData();
                var status = $('#ckStatusM').prop('checked') == true ? 1 : 0;
                //var hot = $('#ckHotM').prop('checked');
                var showHome = $('#ckShowHomeM').prop('checked');

                $.ajax({
                    type: "POST",
                    url: "/Admin/Post/SaveEntity",
                    data: {
                        Id: id,
                        Name: name,
                        CategoryId: categoryId,
                        ThumbnailImage: image,
                        //Price: price,
                        //OriginalPrice: originalPrice,
                        //PromotionPrice: promotionPrice,
                        Description: description,
                        Content: content,
                        HomeFlag: showHome,
                        //HotFlag: hot,
                        Tags: tags,
                        //Unit: unit,
                        Status: status,
                        SeoPageTitle: seoPageTitle,
                        SeoAlias: seoAlias,
                        SeoKeywords: seoKeyword,
                        SeoDescription: seoMetaDescription,
                        IsDeleted: false
                    },
                    dataType: "json",
                    beforeSend: function () {
                        dkteam.startLoading();
                    },
                    success: function (response) {
                        dkteam.notify('Update product successful', 'success');
                        $('#modal-add-edit').modal('hide');
                        resetFormMaintainance();

                        dkteam.stopLoading();
                        loadData(true);
                    },
                    error: function () {
                        dkteam.notify('Has an error in save product progress', 'error');
                        dkteam.stopLoading();
                    }
                });
                return false;
            }
        });
    }

    function registerControls() {
        CKEDITOR.replace('txtContentM', {});

        //Fix: cannot click on element ck in modal
        $.fn.modal.Constructor.prototype.enforceFocus = function () {
            $(document)
                .off('focusin.bs.modal') // guard against infinite focus loop
                .on('focusin.bs.modal', $.proxy(function (e) {
                    if (
                        this.$element[0] !== e.target && !this.$element.has(e.target).length
                        // CKEditor compatibility fix start.
                        && !$(e.target).closest('.cke_dialog, .cke').length
                        // CKEditor compatibility fix end.
                    ) {
                        this.$element.trigger('focus');
                    }
                }, this));
        };

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

    function initTreeDropDownCategory(selectedId) {
        $.ajax({
            url: "/Admin/PostCategory/GetAll",
            type: 'GET',
            dataType: 'json',
            async: false,
            success: function (response) {
                var data = [];
                $.each(response, function (i, item) {
                    data.push({
                        id: item.Id,
                        text: item.Name,
                        parentId: item.ParentId,
                        sortOrder: item.SortOrder
                    });
                });
                var arr = dkteam.unflattern(data);
                $('#ddlCategoryIdM').combotree({
                    data: arr
                });
                if (selectedId != undefined) {
                    $('#ddlCategoryIdM').combotree('setValue', selectedId);
                }
            }
        });
    }

    function resetFormMaintainance() {
        $('#hidIdM').val(0);
        $('#txtNameM').val('');
        initTreeDropDownCategory('');

        $('#txtDescM').val('');
        //$('#txtUnitM').val('');
        //$('#txtOrderM').val('');
        //$('#txtPriceM').val('0');
        //$('#txtOriginalPriceM').val('');
        //$('#txtPromotionPriceM').val('');

        //$('#txtImageM').val('');

        $('#txtTagM').val('');
        $('#txtMetakeywordM').val('');
        $('#txtMetaDescriptionM').val('');
        $('#txtSeoPageTitleM').val('');
        $('#txtSeoAliasM').val('');

        //CKEDITOR.instances.txtContentM.setData('');
        $('#ckStatusM').prop('checked', true);
        //$('#ckHotM').prop('checked', false);
        $('#ckShowHomeM').prop('checked', false);
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