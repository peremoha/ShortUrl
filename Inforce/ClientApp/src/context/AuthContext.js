import React, { useState, useEffect, useContext, createContext } from 'react';
import { useLocalStorage } from '../hooks/useLocalStorage';

const AuthContext = createContext();

export function useAuth() {
    return useContext(AuthContext);
}

export function AuthProvider(props) {
    const [user, setUser] = useState(false);
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const { getItem } = useLocalStorage();

    useEffect(() => {
        const userFromLS = getItem('user');
        
        if (userFromLS) {
            setIsLoggedIn(true);
            setUser(JSON.parse(userFromLS));
        }
    }, [])

    const value = {
        user,
        setUser,
        isLoggedIn,
        setIsLoggedIn
    }

    return (
        <AuthContext.Provider value={value}>{props.children}</AuthContext.Provider>
    )
}