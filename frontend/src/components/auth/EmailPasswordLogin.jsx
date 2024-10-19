import React, { useState } from "react";
import { auth } from "../../services/Firebase";
import axios from "../../services/Axios";

function EmailPasswordLogin() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const handleLogin = async () => {
        try {
            // Đăng nhập với email và password
            const result = await signInWithEmailAndPassword(
                auth,
                email,
                password
            );

            // Lấy ID Token
            const user = result.user;
            const idToken = await user.getIdToken();

            // Gửi ID Token tới backend
            const response = await axios.post("/Auth/login", { idToken });

            // Lưu trữ token và user ID từ backend
            localStorage.setItem("token", response.data.token);
            localStorage.setItem("userId", response.data.userId);

            // Tiếp tục xử lý, chuyển hướng hoặc cập nhật state
        } catch (error) {
            console.error("Đăng nhập thất bại:", error);
        }
    };

    return (
        <div className="max-w-md mx-auto mt-8 p-6 bg-white rounded shadow">
            <h2 className="text-2xl font-semibold mb-4 text-center">
                Đăng nhập
            </h2>
            <div className="mb-4">
                <label className="block text-gray-700">Email</label>
                <input
                    type="email"
                    className="w-full px-4 py-2 mt-2 border rounded focus:outline-none focus:ring-2 focus:ring-blue-600"
                    placeholder="Nhập email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
            </div>
            <div className="mb-6">
                <label className="block text-gray-700">Mật khẩu</label>
                <input
                    type="password"
                    className="w-full px-4 py-2 mt-2 border rounded focus:outline-none focus:ring-2 focus:ring-blue-600"
                    placeholder="Nhập mật khẩu"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
            </div>
            <button
                onClick={handleLogin}
                className="w-full bg-blue-600 text-white py-2 rounded hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-600 focus:ring-opacity-50 transition duration-200"
            >
                Đăng nhập
            </button>
        </div>
    );
}

export default EmailPasswordLogin;
