// src/components/LoginModal.jsx
import React, { useState } from "react";
import { auth, googleProvider } from "../services/Firebase";
import { signInWithPopup } from "firebase/auth";
import axios from "axios";

const LoginModal = ({ onClose }) => {
    const [googleLoading, setGoogleLoading] = useState(false);
    const [emailLoading, setEmailLoading] = useState(false);
    const [error, setError] = useState(null);
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const handleGoogleSignIn = async () => {
        setGoogleLoading(true);
        setError(null);
        try {
            await signInWithPopup(auth, googleProvider);
            // Successfully signed in with Google
            onClose(); // Close the modal after successful login
        } catch (error) {
            console.error("Error during Google sign-in:", error);
            setError(
                error.message || "An error occurred during Google sign-in."
            );
        } finally {
            setGoogleLoading(false);
        }
    };

    const handleEmailSignIn = async (e) => {
        e.preventDefault();
        setEmailLoading(true);
        setError(null);
        try {
            const response = await axios.post("/auth/login", {
                email: email,
                password: password,
            });
            // Handle the response from your backend
            const { token } = response.data;
            // Save token to localStorage or context
            localStorage.setItem("token", token);
            // Close the modal after successful login
            onClose();
        } catch (error) {
            console.error("Error during email sign-in:", error);
            setError(
                error.response?.data?.message ||
                    "An error occurred during email sign-in."
            );
        } finally {
            setEmailLoading(false);
        }
    };

    return (
        <div>
            <h2 id="modal-title" className="text-xl font-semibold mb-4">
                Login
            </h2>
            {error && <p className="text-red-500 mb-4">{error}</p>}
            <form onSubmit={handleEmailSignIn} className="mb-4">
                <div className="mb-2">
                    <label className="block text-gray-700">Email:</label>
                    <input
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        className="w-full px-3 py-2 border rounded"
                        required
                    />
                </div>
                <div className="mb-2">
                    <label className="block text-gray-700">Password:</label>
                    <input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        className="w-full px-3 py-2 border rounded"
                        required
                    />
                </div>
                <button
                    type="submit"
                    disabled={emailLoading}
                    className={`w-full px-4 py-2 bg-green-600 text-white rounded-dm hover:bg-green-700 ${
                        emailLoading ? "opacity-50 cursor-not-allowed" : ""
                    }`}
                >
                    {emailLoading ? "Signing in..." : "Sign in with Email"}
                </button>
            </form>
            <div className="text-center mb-4">Or</div>
            <button
                onClick={handleGoogleSignIn}
                disabled={googleLoading}
                className={`flex items-center justify-center w-full px-4 py-2 bg-white text-black rounded-md border-solid border-2 hover:bg-gray-200 ${
                    googleLoading ? "opacity-80 cursor-not-allowed" : ""
                }`}
            >
                {googleLoading ? (
                    <svg
                        className="animate-spin h-5 w-5 mr-2 border-t-2 border-b-2 border-white rounded-full"
                        viewBox="0 0 24 24"
                    ></svg>
                ) : (
                    <svg
                        xmlns="http://www.w3.org/2000/svg"
                        className="w-6 h-6 mr-2"
                        viewBox="0 0 48 48"
                    >
                        <path
                            fill="#FFC107"
                            d="M43.611,20.083H42V20H24v8h11.303c-1.649,4.657-6.08,8-11.303,8c-6.627,0-12-5.373-12-12c0-6.627,5.373-12,12-12c3.059,0,5.842,1.154,7.961,3.039l5.657-5.657C34.046,6.053,29.268,4,24,4C12.955,4,4,12.955,4,24c0,11.045,8.955,20,20,20c11.045,0,20-8.955,20-20C44,22.659,43.862,21.35,43.611,20.083z"
                        ></path>
                        <path
                            fill="#FF3D00"
                            d="M6.306,14.691l6.571,4.819C14.655,15.108,18.961,12,24,12c3.059,0,5.842,1.154,7.961,3.039l5.657-5.657C34.046,6.053,29.268,4,24,4C16.318,4,9.656,8.337,6.306,14.691z"
                        ></path>
                        <path
                            fill="#4CAF50"
                            d="M24,44c5.166,0,9.86-1.977,13.409-5.192l-6.19-5.238C29.211,35.091,26.715,36,24,36c-5.202,0-9.619-3.317-11.283-7.946l-6.522,5.025C9.505,39.556,16.227,44,24,44z"
                        ></path>
                        <path
                            fill="#1976D2"
                            d="M43.611,20.083H42V20H24v8h11.303c-0.792,2.237-2.231,4.166-4.087,5.571c0.001-0.001,0.002-0.001,0.003-0.002l6.19,5.238C36.971,39.205,44,34,44,24C44,22.659,43.862,21.35,43.611,20.083z"
                        ></path>
                    </svg>
                )}
                {googleLoading ? "Signing in..." : "Sign in with Google"}
            </button>
        </div>
    );
};

export default LoginModal;
