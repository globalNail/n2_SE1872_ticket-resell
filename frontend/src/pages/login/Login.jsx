// src/components/Login.tsx
import React from "react";
import { auth, googleProvider } from "../../services/firebase";
import { GoogleAuthProvider, signInWithPopup } from "firebase/auth";

function Login() {
    const handleGoogleSignIn = async () => {
        try {
            const result = await signInWithPopup(auth, googleProvider);
            // This gives you a Google Access Token. You can use it to access Google APIs.
            const credential = GoogleAuthProvider.credentialFromResult(result);
            const token = credential?.accessToken;

            // The signed-in user info.
            const user = result.user;

            console.log("User Info:", user);
            console.log("Access Token:", token);

            // TODO: Redirect to Admin Dashboard or handle authentication state
        } catch (error) {
            // Handle Errors here.
            const errorCode = error.code;
            const errorMessage = error.message;
            const email = error.email;
            const credential = GoogleAuthProvider.credentialFromError(error);
            console.error(
                "Error during sign-in:",
                errorCode,
                errorMessage,
                email,
                credential
            );
        }
    };

    return (
        <div className="flex items-center justify-center h-screen bg-gray-100">
            <button
                onClick={handleGoogleSignIn}
                className="flex items-center px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700"
            >
                <svg
                    className="w-5 h-5 mr-2"
                    xmlns="http://www.w3.org/2000/svg"
                    viewBox="0 0 48 48"
                >
                    <path
                        fill="#FFC107"
                        d="M43.6,20.3H42V20H24v8h11.3c-0.6,3.5-2.7,6.4-5.8,8.4v6.9h9.3C40.3,39.3,43.6,34.3,43.6,28.1V20.3z"
                    />
                    <path
                        fill="#FF3D00"
                        d="M24,48C14.7,48,7.1,43.1,3.6,35.7L12.3,29c1.6,3.3,5.1,5.7,9.7,5.7c3.1,0,5.9-1.1,8-2.9l6.3,4.9C34.7,46.5,29.4,48,24,48z"
                    />
                    <path
                        fill="#4CAF50"
                        d="M10.3,28c0-2.4,0.2-4.7,0.6-6.9H24v13h-6.3C14.8,40.1,10.3,35.6,10.3,28z"
                    />
                    <path
                        fill="#1976D2"
                        d="M24,9c3.3,0,6.3,1.3,8.6,3.8l6.4-6.4C34.9,2.4,29.4,0,24,0C14.7,0,7.1,4.9,3.6,12.3l8.7,6.5C12.1,17.1,16.6,9,24,9z"
                    />
                </svg>
                Sign in with Google
            </button>
        </div>
    );
}

export default Login;
