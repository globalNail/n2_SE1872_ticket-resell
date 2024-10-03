import axios from "axios";

// const token = localStorage.getItem("token");

const api = axios.create({
    baseURL: import.meta.env.VITE_API_URL,
    headers: {
        "Content-Type": "application/json",
        // Authorization: `Bearer ${token}`,
    },
});

export const getUsers = async () => {
    try {
        const response = await api.get("/Users");
        return response.data;
    } catch (error) {
        console.error("Error fetching users:", error);
        throw error;
    }
};

// Similarly, create functions for other endpoints
export const getTickets = async () => {
    try {
        const response = await api.get("/Tickets");
        return response.data;
    } catch (error) {
        console.error("Error fetching tickets:", error);
        throw error;
    }
};

// Export other API functions as needed
export default api;

//Set Up axios Interceptors
// // src/utils/axiosInstance.js
// import axios from 'axios';
//
// const axiosInstance = axios.create({
//     baseURL: import.meta.env.VITE_API_URL,
// });
//
// // Add a request interceptor
// axiosInstance.interceptors.request.use(
//     (config) => {
//         const token = localStorage.getItem('token'); // Get token from localStorage
//         if (token) {
//             config.headers['Authorization'] = `Bearer ${token}`;
//         }
//         return config;
//     },
//     (error) => {
//         Promise.reject(error);
//     }
// );
//
// export default axiosInstance;
