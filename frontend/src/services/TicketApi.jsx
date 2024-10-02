import api from "./axios";
// Get all tickets
export const getAllTickets = async () => {
    const response = await api.get("/Ticket");
    return response.data;
};

// Get a ticket by ID
export const getTicketById = async (id) => {
    const response = await api.get(`/Ticket/${id}`);
    return response.data;
};

// Create a new ticket
export const createTicket = async (ticket) => {
    const response = await api.post("/Ticket", ticket);
    return response.data;
};

// Update a ticket
export const updateTicket = async (id, ticket) => {
    await api.put(`/Ticket/${id}`, ticket);
};

// Delete a ticket
export const deleteTicket = async (id) => {
    await api.delete(`/Ticket/${id}`);
};
