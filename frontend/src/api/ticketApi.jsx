import { updateTicket } from "../services/TicketApi";
import axiosClient from "./axiosClient";

const ticketApi = {
    getAllTickets: () => {
        const url = "/Ticket";
        return axiosClient.get(url);
    },
    getTicketById: (id) => {
        const url = `/Ticket/${id}`;
        return axiosClient.get(url);
    },
    createTicket: (ticketData) => {
        const url = "/tickets";
        return axiosClient.post(url, ticketData, {
            headers: {
                "Content-Type": "multipart/form-data",
            },
        });
    },
    updateTicket: async (id, ticket) => {
        await api.put(`/Ticket/${id}`, ticket);
    },
    // Các phương thức khác nếu cần
};

export default ticketApi;
