import React from 'react';
import { useContext } from "react";
import { Navigate } from "react-router-dom";
import AuthContext from "../../../contexts/AuthContext";
import type { AuthContextType } from "../../../contexts/AuthContext";
import RequireAuth from "../../../components/RequireAuth";
import Header from "./Header";
import Footer from "./Footer";
import MainContent from "./MainContent";
import './Homepage.css';

const DashBoard: React.FC = () => {
    const auth = useContext(AuthContext) as AuthContextType;


    return (
        <RequireAuth>
            <div className="home">
            <Header />
            <div className="content-wrapper">
                <MainContent />
            </div>
            <Footer />
            </div>
        </RequireAuth>
    );
};

export default DashBoard;