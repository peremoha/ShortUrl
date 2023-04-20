import React, { useEffect, useState } from "react";
import { useAuth } from "../../context/AuthContext";
import { useLocalStorage } from "../../hooks/useLocalStorage";
import { useNavigate } from "react-router-dom";
import './Login.css'

const Login = () => {
    const navigate = useNavigate();
    const { setUser, isLoggedIn, setIsLoggedIn } = useAuth();
    const { setItem } = useLocalStorage();

    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");

    useEffect(() => {
        isLoggedIn && navigate('/')
    }, [isLoggedIn])


    function handleSetLogin(e) {
        setLogin(e.target.value);
    }

    function handleSetPassword(e) {
        setPassword(e.target.value)
    }

    async function handleLogin() {
        await fetch("auth/login",
            {
                method: "POST",
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    Login: login,
                    Password: password
                })
            })
            .then(response => response.json())
            .then(response => {
                setItem('user', JSON.stringify({
                    login: response.login,
                    role: response.role,
                    token: response.token
                }));
                setUser({
                    login: response.login,
                    role: response.role,
                    token: response.token
                });
                setIsLoggedIn(true);
            });
        navigate("/");
    }

    return (
        <form>
            <input type='text' placeholder="Enter login..." value={login} onChange={handleSetLogin} />
            <input text='text' type="password" placeholder="Enter password..." value={password} onChange={handleSetPassword} />
            <button onClick={handleLogin} className="btn btn-primary">Login</button>
        </form>
    )
}

export default Login;