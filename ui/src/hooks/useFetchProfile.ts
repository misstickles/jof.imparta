/* eslint-disable @typescript-eslint/no-explicit-any */
import { profileApi } from "@/api/profileApi";
import { Profile } from "@/types";
import { useEffect, useState } from "react";

const apiUrl = process.env.NEXT_PUBLIC_API_BASE_URL as string;

export function useFetchProfile(userId: string) {
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  const [profile, setProfile] = useState<Profile>({} as Profile);

  useEffect(() => {
    fetchProfileForUser(userId);
  }, [userId]);

  const fetchProfileForUser = async (userId: string) => {
    try {
      const response = await fetch(`${apiUrl}/Profile/${userId}`);

      if (!response.ok) {
        throw new Error(`HTTP error: Status ${response.status}`);
      }

      const profileResponse = await response.json();
      const result = profileResponse.result;

      setProfile(result as Profile);
      setError(null);
    } catch (err: any) {
      setError(err.message);
      setProfile({} as Profile);
    } finally {
      setLoading(false);
    }
  };

  const handleUploadAvatar = async (imageBase64: string, contentType: string) => {
    setLoading(true);

    try {
      const result = await profileApi.create(userId, { imageBase64: imageBase64, contentType: contentType });
      setProfile(result as Profile);
      setError(null);
    } catch (err: any) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  };

  return { profile, error, loading, handleUploadAvatar };
}
