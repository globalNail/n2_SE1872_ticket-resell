import axios from "axios";

const token = localStorage.getItem("token");

const api = axios.create({
    baseURL: import.meta.env.VITE_API_URL,
    headers: {
        // "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
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
