// src/context/AuthContext.tsx
import React, { createContext, useState, useEffect} from 'react';
import axios from 'axios';
import type { ReactNode } from 'react';

export interface User {
    username: string;
    // Other user properties to be added here
  }

export interface AuthContextType {
    user: User | null;
    login: (username: string, password: string) => Promise<boolean>;
    logout: () => void;
    loading: boolean;
}

const AuthContext = createContext<AuthContextType | null>(null);


export const AuthProvider = ({ children }: { children: ReactNode }) => {
  const [user, setUser] =  useState<User | null>(null);
  const [loading, setLoading] = useState(true);

  // Check if user is already logged in
  useEffect(() => {
    const token = localStorage.getItem('token');
    if (token) {
      // Set up axios defaults
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;

      const userString = localStorage.getItem('user');
      if (userString) {
        setUser(JSON.parse(userString));
    }
}
    setLoading(false);
  }, []);

  // Login function
  const login = async (username : String, password : String) => {
    try {
      const response = await axios.post('http://localhost:5166/api/Auth/login', { 
        username, 
        password 
      });
      
      const { token, username: userName } = response.data;
      
      // Save to localStorage
      localStorage.setItem('token', token);
      localStorage.setItem('user', JSON.stringify({ username: userName }));
      
      // Set authorization header
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;
      
      setUser({ username: userName });
      return true;
    } catch (error) {
      console.error('Login failed:', error);
      return false;
    }
  };

  // Logout function
  const logout = () => {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    delete axios.defaults.headers.common['Authorization'];
    setUser(null);
  };

  return (
    <AuthContext.Provider value={{ user, login, logout, loading }}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthContext;

