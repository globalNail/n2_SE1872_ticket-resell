// Logout.js
import React from "react";
import firebase from "../../services/Firebase";

function Logout() {
    const handleLogout = async () => {
        try {
            await firebase.auth().signOut();
            localStorage.removeItem("token");
            localStorage.removeItem("userId");
            // Chuyển hướng hoặc cập nhật state
        } catch (error) {
            console.error("Đăng xuất thất bại:", error);
        }
    };

    return <button onClick={handleLogout}>Đăng xuất</button>;
}

export default Logout;
