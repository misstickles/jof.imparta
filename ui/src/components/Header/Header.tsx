import { useState } from "react";
import { UserAvatar } from "./UserAvatar";
import { Loading } from "../Core";
import { Alert, Stack, Typography } from "@mui/material";
import { Profile, Task } from "@/types";
import { TaskStatusCount } from "../Task/TaskStatusCount";
import { EditAvatar } from "../Modify";

interface HeaderProps {
  tasks: Task[];
  profile: Profile;
  loading: boolean;
  error: string | null;
  onAvatarClick: (imageBase64: string, contentType: string) => void;
}

export const Header = ({ tasks, profile, loading, error, onAvatarClick }: HeaderProps) => {
  const [editAvatar, setEditAvatar] = useState(false);

  if (loading) return <Loading size={30} />;

  const handleAvatarUpdate = (imageBase64: string, contentType: string) => {
    // hack, since we're only storing base64 and have validation on it...
    const b64 = imageBase64.split(",")[1];
    onAvatarClick(b64, contentType);
    setEditAvatar(false);
  };

  const handleAvatarClick = () => {
    setEditAvatar(true);
  };

  const onCloseEdit = () => {
    setEditAvatar(false);
  };

  return (
    <>
      {error && <Alert severity="error">Error: {error}</Alert>}
      <Stack direction={"row"} sx={{ justifyContent: "space-between", alignItems: "center", width: "100%" }}>
        <UserAvatar profile={profile} onAvatarClick={handleAvatarClick} />
        <Typography variant="h4" component={"h6"}>
          My Task List
        </Typography>
        <Typography sx={{ width: 80 }}>&nbsp;</Typography>
      </Stack>
      {editAvatar && <EditAvatar onCloseEdit={onCloseEdit} onUpdateAvatar={handleAvatarUpdate} />}
      {tasks && <TaskStatusCount tasks={tasks} />}
    </>
  );
};
