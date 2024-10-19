import React, { useState } from "react";
import { auth } from "../../services/Firebase";
import { Form } from "antd";

export default function RegisterForm() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const handleRegister = async () => {
        try {
            // Tạo tài khoản mới
            await firebase
                .auth()
                .createUserWithEmailAndPassword(email, password);
            alert("Đăng ký thành công!");
            // Chuyển hướng hoặc xử lý tiếp
        } catch (error) {
            console.error("Đăng ký thất bại:", error);
        }
    };

    return (
        <div>
            <h2>Đăng ký tài khoản mới</h2>
            <input
                type="email"
                placeholder="Email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
            />
            <input
                type="password"
                placeholder="Mật khẩu"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
            />
            <button onClick={handleRegister}>Đăng ký</button>
        </div>
    );
}
