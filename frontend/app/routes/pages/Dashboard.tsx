import React from 'react';
import { useContext } from "react";
import { Navigate } from "react-router-dom";
import AuthContext from "../../contexts/AuthContext";
import type { AuthContextType } from "../../contexts/AuthContext";
import RequireAuth from "../../components/RequireAuth";

const DashBoard: React.FC = () => {
    const auth = useContext(AuthContext) as AuthContextType;


    return (
        <RequireAuth>
            <div style={{ padding: '20px' }}>
                <h1>Welcome to the Dashboard</h1>
                <p>This is your default landing page.</p>
            </div>
        </RequireAuth>
    );
};

export default DashBoard;