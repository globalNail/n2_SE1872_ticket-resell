// src/pages/SignupPage.jsx
import React, { useState } from "react";
import { useNavigate, Link } from "react-router-dom";
// Import your authentication API functions here

function Signup() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [error, setError] = useState(null);

    const navigate = useNavigate();

    const handleSignup = async (e) => {
        e.preventDefault();
        if (password !== confirmPassword) {
            setError("Passwords don't match.");
            return;
        }
        try {
            // Replace with your actual signup API call
            // const response = await signupUser({ email, password });
            // Handle authentication (e.g., store tokens)
            console.log("Signed up:", { email, password });
            navigate("/profile");
        } catch (err) {
            setError("Signup failed.");
            console.error("Signup error:", err);
        }
    };

    return (
        <div className="container mx-auto p-6 max-w-md">
            <h1 className="text-3xl font-bold mb-6">Signup</h1>
            {error && <div className="text-red-500 mb-4">{error}</div>}
            <form onSubmit={handleSignup}>
                <div className="mb-4">
                    <label htmlFor="email" className="block text-gray-700">
                        Email:
                    </label>
                    <input
                        type="email"
                        id="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                        className="w-full border px-3 py-2 rounded"
                    />
                </div>
                <div className="mb-4">
                    <label htmlFor="password" className="block text-gray-700">
                        Password:
                    </label>
                    <input
                        type="password"
                        id="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                        minLength={6}
                        className="w-full border px-3 py-2 rounded"
                    />
                </div>
                <div className="mb-6">
                    <label
                        htmlFor="confirmPassword"
                        className="block text-gray-700"
                    >
                        Confirm Password:
                    </label>
                    <input
                        type="password"
                        id="confirmPassword"
                        value={confirmPassword}
                        onChange={(e) => setConfirmPassword(e.target.value)}
                        required
                        minLength={6}
                        className="w-full border px-3 py-2 rounded"
                    />
                </div>
                <button
                    type="submit"
                    className="bg-purple-500 text-white px-6 py-2 rounded hover:bg-purple-600"
                >
                    Signup
                </button>
            </form>
            <p className="mt-4">
                Already have an account?{" "}
                <Link to="/login" className="text-blue-500">
                    Login here
                </Link>
                .
            </p>
        </div>
    );
}

export default Signup;
