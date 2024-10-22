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
};

export default ticketApi;
