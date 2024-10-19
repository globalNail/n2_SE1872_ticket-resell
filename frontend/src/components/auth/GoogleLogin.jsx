import React from "react";
import { auth, googleProvider } from "../../services/Firebase";
import { signInWithPopup } from "firebase/auth";
import axios from "../../services/Axios";

function GoogleLogin() {
    const handleLogin = async () => {
        try {
            const result = await signInWithPopup(auth, googleProvider);
            // const user = result.user;
            // const idToken = await user.getIdToken();
            const idToken = await result.user.getIdToken();

            const response = await axios.post("/Auth/login", { idToken });

            // Lưu trữ token và user ID từ backend
            localStorage.setItem("token", response.data.token);
            localStorage.setItem("userId", response.data.userId);
        } catch (error) {
            console.error("Đăng nhập thất bại:", error);
        }
    };

    return (
        <div className="max-w-md mx-auto mt-4 p-6 bg-white rounded shadow text-center">
            <button
                onClick={handleLogin}
                className="w-full flex items-center justify-center bg-red-600 text-white py-2 rounded hover:bg-red-700 transition duration-200"
            >
                <svg className="w-5 h-5 mr-2" viewBox="0 0 48 48">
                    {/* SVG của biểu tượng Google */}
                </svg>
                Đăng nhập với Google
            </button>
        </div>
    );
}

export default GoogleLogin;
