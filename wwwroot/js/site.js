﻿document.getElementById("createUserForm")?.addEventListener("submit", function (event) {
    event.preventDefault();

    let userName = document.getElementById("userName").value;
    let userPassword = document.getElementById("userPassword").value;
    let userRole = document.getElementById("userRole").value;
    let shopName = document.getElementById("shopName").value;

    fetch("/User/Create", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            name: userName,
            password: userPassword,
            role: parseInt(userRole),
            shopName: shopName || null
        })
    })
    .then(response => response.json().then(data => ({ status: response.status, body: data })))
    .then(({ status, body }) => {
        if (status === 200) {
            alert("User added successfully!");
            
            let table = document.getElementById("usersTableBody");
            let row = table.insertRow();
            row.insertCell(0).textContent = body.shop ? body.shop.name : "No Shop";
            row.insertCell(1).textContent = body.name;
            row.insertCell(2).textContent = body.role;
            
            document.getElementById("createUserForm").reset();
            var modal = bootstrap.Modal.getInstance(document.getElementById("createUserModal"));
            modal.hide();
        } else {
            alert("Error: " + (body.message || "An unexpected error occurred"));
        }
    })
    .catch(error => {
        alert("Error: " + error.message);
        console.error("Error:", error.message);
    });
});
function deleteUser(name) {
    if (!confirm("Are you sure you want to delete this user?")) {
        return;
    }

    fetch("/User/Delete", {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ userName: name })
    })
        .then(response => {
            console.log(response);
            if (!response.ok) {
                throw new Error("Failed to delete user.");
            }
            return response.json();
        })
        .then(data => {
            alert(data.message);
            location.reload(); // Перезагрузка страницы
        })
        .catch(error => {
            console.error("Error:", error);
            alert("Error deleting user.",error.message);
        });
}
function deleteShop(shopId) {
    if (!confirm("Are you sure you want to delete this shop?")) {
        return;
    }

    fetch(`/Shop/Delete`, {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ ShopId: shopId })
    })
        .then(response => {
            if (!response.ok) {
                throw new Error("Failed to delete shop.");
            }
            return response.json();
        })
        .then(data => {
            alert(data.message);
            location.reload();
        })
        .catch(error => {
            console.error("Error:", error);
            alert("Error deleting shop.",error.message);
        });
}
function editUser(id, name, password, role, shopName) {
    document.getElementById("editUserId").value = id;
    document.getElementById("editUserName").value = name;
    document.getElementById("editUserPassword").value = ""; // Очистка пароля
    document.getElementById("editUserRole").value = role;
    document.getElementById("editUserShop").value = shopName;
}
function deleteProduct(productId) {
    console.log(productId)
    productId = parseInt(productId);
    if (!confirm("Are you sure you want to delete this product?")) {
        return;
    }

    fetch(`/Product/Delete`, {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ ProductId: productId })

    })
        .then(response => {
            if (!response.ok) {
                throw new Error("Failed to delete shop.");
            }
            return response.json();
        })
        .then(data => {
            alert(data.message);
            location.reload();
        })
        .catch(error => {
            console.error("Error:", error);
            alert("Error deleting product.",error.message);
        });
}
document.getElementById("createShopForm")?.addEventListener("submit", function (event) {
    event.preventDefault();

    let shopName = document.getElementById("createShopName").value.trim();
    let managerName = document.getElementById("createManagerName").value.trim();
    let shopTable = document.getElementById("shopTableBody");
    console.log(shopTable);
    fetch("/Shop/Create", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            name: shopName,
            managerName: managerName || null
        })
    })
        .then(response => response.json())
        .then(data => {
            alert("Shop added successfully!");


            // Добавляем новый магазин в таблицу магазинов
            let shopTable = document.getElementById("shopTableBody");
            let row = shopTable.insertRow();
            row.insertCell(0).textContent = data.id;
            row.insertCell(1).textContent = data.name;
            row.insertCell(2).textContent = data.manager ? data.manager.name : "No Manager";

            // Добавляем новый магазин в список магазинов при создании пользователя
            let shopSelect = document.getElementById("shopName");
            if (shopSelect) {  // Проверяем, существует ли select
                let option = document.createElement("option");
                option.value = data.id; // Используем id вместо имени
                option.textContent = data.name;
                shopSelect.appendChild(option);
            }

            document.getElementById("createShopForm").reset();

            // Закрытие модального окна
            var modalElement = document.getElementById("createShopModal");
            if (modalElement) {
                var modal = bootstrap.Modal.getInstance(modalElement);
                if (modal) modal.hide();
            }
        })
        .catch(error => {
            console.error("Error:", error);
            alert("Error adding shop.",error.message);
        });
});

document.addEventListener("DOMContentLoaded", function () {
    const createProductForm = document.getElementById("createProductForm");
    if (createProductForm && !createProductForm.hasAttribute('data-listener-attached')) {
        createProductForm.addEventListener("submit", async function (event) {
            event.preventDefault();

            let productName = document.getElementById("createProductName").value;
            let quantity = parseInt(document.getElementById("createQuantity").value);
            let price = parseInt(document.getElementById("createPrice").value);
            let shopId = window.location.pathname.split("/").pop();
            let requestData = {
                Name: productName,
                Quantity: quantity,
                Price: price,
                ShopId: parseInt(shopId)
            };

            console.log(requestData);

            let response = await fetch("/Product/AddProduct", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(requestData)
            });

            if (response.ok) {
                alert("Product added successfully!");
                location.reload();
            } else {
                let errorText = await response.text();
                alert("Error: " + errorText);
            }
        });

        createProductForm.setAttribute('data-listener-attached', 'true');
    }
});
document.getElementById("editUserForm")?.addEventListener("submit", function (event) {
    event.preventDefault(); // Предотвращаем стандартное поведение формы

    let userId = document.getElementById("editUserId").value;
    let name = document.getElementById("editUserName").value;
    let password = document.getElementById("editUserPassword").value;
    let role = document.getElementById("editUserRole").value;
    let shopName = document.getElementById("editUserShop").value;
    
    let data = {
        userId: parseInt(userId),
        name: name.trim() !== "" ? name : null,
        password: password.trim() !== "" ? password : null,
        role: role ? parseInt(role) : null,
        shopName: shopName ? shopName.trim() : null
    };

    fetch("/User/Edit", {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error("Failed to update user");
            }
            return response.json();
        })
        .then(updatedUser => {
            alert("User updated successfully!");
            location.reload(); // Перезагружаем страницу для обновления данных
        })
        .catch(error => {
            console.error("Error:", error);
            alert("Error updating user: " + error.message);
        });
});
function editShop(id, name, managerName) {
    document.getElementById("editShopId").value = id;
    document.getElementById("editShopName").value = name;
    document.getElementById("editShopManager").value = managerName;
}
document.getElementById("editShopForm")?.addEventListener("submit", function (event) {
    event.preventDefault();

    let shopId = document.getElementById("editShopId").value;
    let shopName = document.getElementById("editShopName").value.trim();
    let manager = document.getElementById("editShopManager").value.trim();

    let data = {
        shopId: parseInt(shopId),
        shopName: shopName,
        managerName: manager
    };

    fetch("/Shop/Edit", {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error("Failed to update shop");
            }
            return response.json();
        })
        .then(updatedShop => {
            alert("Shop updated successfully!");
            location.reload();
        })
        .catch(error => {
            console.error("Error:", error);
            alert("Error updating shop: " + error.message);
        });
});
function editProduct(id, name, quantity, price) {
    console.log("123")
    document.getElementById("editProductId").value = id;
    document.getElementById("editProductName").value = name;
    document.getElementById("editProductQuantity").value = quantity;
    document.getElementById("editProductPrice").value = price;
}
document.addEventListener("submit", function (event) {
    let form = event.target.closest("#editProductForm");
    if (!form) return; // Если форма не найдена, ничего не делаем

    event.preventDefault();

    let productId = document.getElementById("editProductId").value;
    let productName = document.getElementById("editProductName").value.trim();
    let productQuantity = parseInt(document.getElementById("editProductQuantity").value);
    let productPrice = parseFloat(document.getElementById("editProductPrice").value);

    let data = {
        id: productId,
        name: productName,
        quantity: productQuantity,
        price: productPrice
    };

    fetch("/Product/Edit", {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error("Failed to update product");
            }
            return response.json();
        })
        .then(updatedProduct => {
            alert("Product updated successfully!");
            location.reload();
        })
        .catch(error => {
            console.error("Error:", error);
            alert("Error updating product: " + error.message);
        });
});
document.getElementById("addSellerButton")?.addEventListener("click", async function () {
    let username = document.getElementById("sellerUsername").value.trim();
    let shopId = document.getElementById("shopId").value;
    let errorDiv = document.getElementById("addSellerError");

    // Очистка ошибок перед отправкой запроса
    errorDiv.style.display = "none";
    errorDiv.textContent = "";

    if (!username) {
        errorDiv.textContent = "Please enter a username.";
        errorDiv.style.display = "block";
        return;
    }

    let requestData = {
        ShopId: parseInt(shopId),
        UserName: username
    };

    try {
        let response = await fetch("/Shop/AddSeller", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(requestData)
        });

        if (!response.ok) {
            let errorMessage = await response.text();
            throw new Error(errorMessage || "Failed to add seller.");
        }

        alert("Seller added successfully!");
        location.reload(); // Перезагрузка страницы для обновления данных
    } catch (error) {
        errorDiv.textContent = error.message;
        errorDiv.style.display = "block";
    }
});

