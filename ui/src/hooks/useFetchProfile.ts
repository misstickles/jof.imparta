/* eslint-disable @typescript-eslint/no-explicit-any */
import { Profile } from "@/types";
import { useEffect, useState } from "react";

const apiUrl = process.env.NEXT_PUBLIC_API_BASE_URL as string;

export function useFetchProfile(userId: string) {
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const [profile, setProfile] = useState<Profile>({} as Profile);

  useEffect(() => {
    const fetchProfileForUser = async (userId: string) => {
      try {
        const response = await fetch(`${apiUrl}/Profile/${userId}`);

        if (!response.ok) {
          throw new Error(`HTTP error: Status ${response.status}`);
        }

        const profileResponse = await response.json();

        const result = profileResponse.result;

        setProfile({ userId: result.userId, imageBase64: result.imageBase64, contentType: result.contentType });
        setError(null);
      } catch (err: any) {
        setError(err.message);
        setProfile({} as Profile);
      } finally {
        setLoading(false);
      }
    };

    fetchProfileForUser(userId);
  }, [userId]);

  return { profile, error, loading };
}
