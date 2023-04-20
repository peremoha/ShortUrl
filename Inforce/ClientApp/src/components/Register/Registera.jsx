import React, { useState, useEffect } from "react";
import { useAuth } from "../../context/AuthContext";
import { Navigate, useNavigate } from "react-router-dom";
import './Register.css'

const Registera = () => {
    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");

    const { isLoggedIn } = useAuth();

    useEffect(() => {
        isLoggedIn && navigate('/')
    }, [isLoggedIn])

    const navigate = useNavigate();

    function handleSetLogin(e){
        setLogin(e.target.value);
    }

    function handleSetPassword(e){
        setPassword(e.target.value)
    }

    async function registration(){
        await fetch("auth/register",
        {
            method: "POST",
            headers: {'Content-Type' : 'application/json'},
            body: JSON.stringify({
                Login: login,
                Password: password
            })
        });
        navigate("/");

    }

    return (
        <form>
            <input type='text' placeholder="Enter login..." value={login} onChange={handleSetLogin} />
            <input text='text' type="password" placeholder="Enter password..." value={password} onChange={handleSetPassword} />
            <button onClick={registration} className="btn btn-primary">Register</button>
        </form>
    )
}

export default Registera;