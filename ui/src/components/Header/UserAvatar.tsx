import { Profile } from "@/types";
import { Avatar } from "@mui/material";

interface UserAvatarProps {
  profile: Profile;
}

export const UserAvatar = ({ profile }: UserAvatarProps) => {
  return (
    <Avatar
      src={`data:${profile.contentType};base64, ${profile.imageBase64}`}
      alt="Avatar"
      sx={{ width: 80, height: 80 }}
    />
  );
};
