/* eslint-disable @typescript-eslint/no-explicit-any */
import { fetchFromApi } from "./fetchFromApi";

export const profileApi = {
  get: async (userId: string) =>
    fetchFromApi(`/Profile/${userId}`, {
      method: "GET",
    }),

  create: async (userId: string, request: any) =>
    fetchFromApi(`/Profile/${userId}`, {
      method: "POST",
      body: JSON.stringify(request),
    }),
};
