import React from "react";
import EmailPasswordLogin from "./EmailPasswordLogin";
import GoogleLogin from "./GoogleLogin";

function Login() {
    return (
        <div className="min-h-screen flex items-center justify-center bg-gray-100">
            <div>
                <EmailPasswordLogin />
                <div className="text-center my-4">Hoặc</div>
                <GoogleLogin />
            </div>
        </div>
    );
}

export default Login;
