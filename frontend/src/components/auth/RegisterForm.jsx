import React, { useState } from "react";
import authApi from "../api/auth";

function RegisterForm() {
    const [userInfo, setUserInfo] = useState({
        email: "",
        username: "",
        password: "",
    });

    const handleChange = (e) => {
        setUserInfo({
            ...userInfo,
            [e.target.name]: e.target.value,
        });
    };

    const handleRegister = async (e) => {
        e.preventDefault();
        try {
            const response = await authApi.register(userInfo);
            // Xử lý sau khi đăng ký thành công
        } catch (error) {
            console.error("Lỗi đăng ký:", error.response.data);
        }
    };

    return (
        <form onSubmit={handleRegister}>
            <input
                type="email"
                name="email"
                onChange={handleChange}
                placeholder="Email"
            />
            <input
                type="text"
                name="username"
                onChange={handleChange}
                placeholder="Tên đăng nhập"
            />
            <input
                type="password"
                name="password"
                onChange={handleChange}
                placeholder="Mật khẩu"
            />
            <button type="submit">Đăng ký</button>
        </form>
    );
}

export default RegisterForm;
