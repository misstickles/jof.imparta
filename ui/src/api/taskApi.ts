/* eslint-disable @typescript-eslint/no-explicit-any */
import { fetchFromApi } from "./fetchFromApi";

export const taskApi = {
  getAll: async (userId: string) =>
    fetchFromApi(`/Task/${userId}`, {
      method: "GET",
    }),

  create: async (request: any) =>
    fetchFromApi("/Task", {
      method: "POST",
      body: JSON.stringify(request),
    }),

  update: async (request: any) =>
    fetchFromApi("/Task", {
      method: "PUT",
      body: JSON.stringify(request),
    }),

  delete: async (request: any) =>
    fetchFromApi("/Task", {
      method: "DELETE",
      body: JSON.stringify(request),
    }),
};
