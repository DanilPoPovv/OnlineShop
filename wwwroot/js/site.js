document.getElementById("createUserForm").addEventListener("submit", function (event) {
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
        .then(response => response.json())
        .then(data => {
            alert("User added successfully!");

            // Add new user to the table without reloading
            let table = document.getElementById("usersTableBody");
            let row = table.insertRow();
            row.insertCell(0).textContent = data.shop ? data.shop.name : "No Shop";
            row.insertCell(1).textContent = data.name;
            row.insertCell(2).textContent = data.role;

            // Close modal and reset form
            document.getElementById("createUserForm").reset();
            var modal = bootstrap.Modal.getInstance(document.getElementById("createUserModal"));
            modal.hide();
        })
        .catch(error => console.error("Error:", error));
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
            alert("Error deleting user.");
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
            alert("Error deleting shop.");
        });
}
document.getElementById("createShopForm").addEventListener("submit", function (event) {
    event.preventDefault();

    let shopName = document.getElementById("createShopName").value;
    let managerName = document.getElementById("createManagerName").value;
    if (!shopName.trim() && !managerName.trim()) {
        alert("Both fields are empty!");
        return;
    }

    fetch("/Shop/Create", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },

        body: JSON.stringify({
            Name: shopName.trim(),
            managerName: managerName.trim() || null
        }),
    })
        .then(response => {
            if (!response.ok) {
                throw new Error("Failed to create shop.");
            }
            return response.json();
        })
        .then(data => {
            alert("Shop added successfully!");

            // Закрытие модального окна
            let modal = bootstrap.Modal.getInstance(document.getElementById("createShopModal"));
            modal.hide();

            // Очистка формы
            document.getElementById("createShopForm").reset();

            // Добавление в таблицу без перезагрузки (если нужно)
            let table = document.querySelector("tbody"); // Найди таблицу магазинов
            let row = table.insertRow();
            row.insertCell(0).textContent = data.id;
            row.insertCell(1).textContent = data.name;
            let cell3 = row.insertCell(2);
            let viewButton = document.createElement("a");
            viewButton.href = `/Shop/Index/${data.id}`;
            viewButton.classList.add("btn", "btn-info");
            viewButton.textContent = "View Shop";
            cell3.appendChild(viewButton);
        })
        .catch(error => {
            console.error("Error:", error);
            alert("Error adding shop.");
        });
});