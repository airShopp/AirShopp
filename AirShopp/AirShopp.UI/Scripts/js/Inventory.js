function editProduct(v) {
    var ProductId = v;
    $("#inventoryP").empty();
    $("#inventoryP").append(
            '<dt style="display:none;"><input type="hidden" name="product.productId" id="pId" /></dt>' +
            '<dt>商品名：</dt>' +
            '<dd><input id="productName" type="text" name="product.productName" style="margin-right:24px;height:25px;line-height:25px" /></dd>'+
            '<dt>商品价格：</dt>'+
            '<dd><input type="text" name="product.price" id="price" style="margin-right:12px;height:25px;line-height:25px" />元</dd>'+

            '<dt>选择图片：</dt>'+
            '<dd><input type="file" name="image" style="margin-left:65px;height:25px;line-height:25px" /></dd>'+
            '<dt>折扣：</dt>'+
            '<dd><input id="discounts" type="text" name="discounts" style="margin-right:12px;height:25px;line-height:25px" />折</dd>'+
            '<dt>是否上架：</dt>'+
            '<dd><select name="product.isOnsale" id="IsOnSale" style="margin-left:65px;margin-top:10px; height:25px;line-height:25px"></select></dd>'+
            '<dt><input type="button" value="提交修改" onclick="updateProduct()" style="width:60px;height:25px;margin-left:275px;" /></dt>');
    $.ajax({
        type: "Get",
        url: "/Inventory/GetInventoryProductDetail",
        dataType:"JSON",
        data: {
            "productId": ProductId
        },
        success: function (result) {
           
            //window.alert(result.productDataModel.ProductName);
            $("#pId").val(result.productDataModel.ProductId)
            $("#productName").val(result.productDataModel.ProductName);
            $("#price").val(result.productDataModel.Price);
            if (result.productDataModel.IsOnSale == true) {
                $("#IsOnSale").append("<option style='color:red;' value=" + true + " selected >上架</option>");
                $("#IsOnSale").append("<option value=" + false + ">下架</option>");
            }
            else {
                $("#IsOnSale").append("<option value=" + true + " >上架</option>");
                $("#IsOnSale").append("<option style='color:red;' value=" + false + " selected style='font-color:red;'>下架</option>");
            }
            $("#discounts").val(result.productDataModel.Discounts);

            $(".box111").css({ "display": "block" });
            $(".hint111").css({ "display": "block" });
        },
        error: function (result) {
            window.alert("sdfsdf");
            $(".box111").css({ "display": "block" });
            $(".hint111").css({ "display": "block" });
            
        }
    });

    //var ProductId = $("#productId").val();
    //var url = "/Inventory/GetInventoryProductDetail?productId=" + ProductId;
    //$.getJSON(url, function (data) {
    //    window.alert(data.productDataModel.ProductName);
    //    var productName = data.productDataModel.productName;
    //    $(".box111").css({ "display": "block" });
    //    $(".hint111").css({ "display": "block" });
    //});
}

function updateProduct()
{
    var productId = $("#pId").val();
    var productName = $("#productName").val();
    var price = $("#price").val();
    var discounts = $("#discounts").val();
    var isOnSale = $("#IsOnSale").val();
    var image = $("#pictureUrl").val();
    if (productName == "" || price == "" || discounts == "" || isOnSale == "") {
        if (productName == "") {
            window.alert("商品名不能为空");
            $("#productName").css('border-color', 'red');
        }
        if (price == "") {
            window.alert("价格不能为空");
            $("#price").css("border-color", "Red");
        }
        if (discounts == "") {
            window.alert("商品折扣不能为空");
            $("#discounts").css("border-color", "Red");
        }
        if (isOnSale == "") {
            window.alert("请选择商品是否上架");
            $("#discounts").css("border-color", "Red");
        }
    }
    else {
        $("#FormSub").ajaxSubmit({
            success: function (result) {
                setTimeout(function () { window.location.reload(); }, 1500);
                $("#msg").html(result);
                $(".box111").css({ "display": "none" });
                $(".hint111").css({ "display": "none" });
                $("#flashBox").css({ "display": "block" });
                $("#flashBox").delay(2000).hide(0);
            }
        });
    }
    //$.ajax({
    //    type: "Get",
    //    url: "/Inventory/UpdateProduct",
    //    dataType:"Json",
    //    data: {
    //        "product.productId": productId,
    //        "product.productName": productName,
    //        "product.price": price,
    //        "product.discounts": discounts,
    //        "product.isOnSale": isOnSale,
    //        "image": 
    //    },
    //    success: function (result) {
    //        $("#msg").html(result);
    //        $("#flashBox").css({ "display": "block" });
    //        $("#flashBox").delay(1000).hide(0);
    //        $(".box111").css({ "display": "none" });
    //        $(".hint111").css({ "display": "none" });
    //    }
    //});
}

//Delete Product
var productId;;
function deleteProduct(id)
{
    productId = id;
    $("#pop").css("display", "block");

    //$.ajax({
    //    type: "Get",
    //    url: "/Inventory/DeleteProdct",
    //    data: {
    //        "productId":id
    //    },
    //    success: function ()
    //    {
    //        $("#msg").html("删除成功");
    //        $("#flashBox").css({ "display": "block" });
    //        $("#flashBox").delay(1000).hide(0);
    //        location.reload();
    //    }
    //});
}
function CancelDelete() {
    $("#pop").css("display", "none");
}
function ConfirmDelete() {
    $.ajax({
        type: "Get",
        url: "/Inventory/DeleteProdct",
        data: {
            "productId": productId
        },
        success: function () {
            setTimeout(function () { window.location.reload(); }, 1500);
            $("#pop").css("display", "none");
            $("#msg").html("删除成功");
            $("#flashBox").css({ "display": "block" });
            $("#flashBox").delay(1600).hide(0);
        }
    });
}

function AddProduct() {
    var productName = $("#pt").val();
    var productionTime = $("#ppt").val();
    var keepData = $("#pkt").val();
    var productAmount = $("#ppc").val();
    if (productName == "" || productionTime == "" || keepData == "" || productAmount == "") {
        if (productName == "") {
            $("#pt").css("border-color", "Red");
        }
        if (productName == "") {
            $("#ppt").css("border-color", "Red");
        }
        if (productName == "") {
            $("#pkt").css("border-color", "Red");
        }
        if (productName == "") {
            $("#ppc").css("border-color", "Red");
        }
    }
    else {
        $("#AddForm").submit();
    }
}