// src/contexts/AuthContext.jsx
import React, { createContext, useState, useEffect, useContext } from "react";
import { auth } from "../services/Firebase";
import { onAuthStateChanged } from "firebase/auth";

// Create the AuthContext
export const AuthContext = createContext({
    currentUser: null,
});

// AuthProvider component to provide authentication state
export const AuthProvider = ({ children }) => {
    const [currentUser, setCurrentUser] = useState(null);

    useEffect(() => {
        const unsubscribe = onAuthStateChanged(auth, (user) => {
            setCurrentUser(user);
        });

        return () => unsubscribe();
    }, []);

    return (
        <AuthContext.Provider value={{ currentUser }}>
            {children}
        </AuthContext.Provider>
    );
};

// Custom hook to use AuthContext
export const useAuth = () => {
    return useContext(AuthContext);
};
