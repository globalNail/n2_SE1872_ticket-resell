import React from "react";
import { GoogleAuthProvider, signInWithPopup } from "firebase/auth";
import { auth } from "../../services/Firebase";
import authApi from "../api/auth";

function GoogleLoginButton() {
    const handleGoogleLogin = async () => {
        const provider = new GoogleAuthProvider();
        try {
            const result = await signInWithPopup(auth, provider);
            const idToken = await result.user.getIdToken();

            // Gửi idToken đến backend
            const response = await authApi.googleLogin(idToken);

            // Lưu token JWT
            localStorage.setItem("token", response.data.token);
        } catch (error) {
            console.error("Lỗi đăng nhập Google:", error);
        }
    };

    return <button onClick={handleGoogleLogin}>Đăng nhập với Google</button>;
}

export default GoogleLoginButton;
