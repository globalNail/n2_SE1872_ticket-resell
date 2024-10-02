import React, { createContext, useState, useEffect } from "react";
import { auth } from "../services/Firebase";
import { onAuthStateChanged } from "firebase/auth";

export const AuthContext = createContext({
    currentUser: null,
});

export const AuthProvider = ({ children }) => {
    const [currentUser, setCurrentUser] = useState(null);
    // const googleSignIn = () => {
    //     const provider = new GoogleAuthProvider();
    //     signInWithPopup(auth, provider);
    // };
    // const logOut = () => {
    //     signOut(auth);
    // };
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
export const UserAuth = () => {
    return useContext(AuthContext);
};
