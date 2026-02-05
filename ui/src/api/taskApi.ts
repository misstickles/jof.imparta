/* eslint-disable @typescript-eslint/no-explicit-any */
import { fetchFromApi } from "./fetchFromApi";

export const taskApi = {
  getAll: async (userId: string) =>
    fetchFromApi(`/Task?userId=${userId}`, {
      method: "GET",
    }),

  create: async (request: any) =>
    fetchFromApi("/Task", {
      method: "POST",
      body: JSON.stringify(request),
    }),

  update: async (taskId: string, request: any) =>
    fetchFromApi(`/Task/${taskId}`, {
      method: "PUT",
      body: JSON.stringify(request),
    }),

  delete: async (taskId: string, userId: string) =>
    fetchFromApi(`/Task/${taskId}?userId=${userId}`, {
      method: "DELETE",
    }),
};
