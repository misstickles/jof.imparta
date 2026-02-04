import { Profile } from "@/types";
import { Avatar, Button } from "@mui/material";

interface UserAvatarProps {
  profile: Profile;
  onAvatarClick: () => void;
}

export const UserAvatar = ({ profile, onAvatarClick }: UserAvatarProps) => {
  return (
    <Button title="Change my avatar" onClick={onAvatarClick}>
      <Avatar
        src={`data:${profile.contentType};base64, ${profile.imageBase64}`}
        alt="Avatar"
        sx={{ width: 80, height: 80 }}
      />
    </Button>
  );
};
