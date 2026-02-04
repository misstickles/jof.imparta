/* eslint-disable @typescript-eslint/no-explicit-any */
import { Button, Stack, Typography } from "@mui/material";
import styles from "@/app/page.module.css";

import CloseIcon from "@mui/icons-material/Close";

interface EditAvatarProps {
  onCloseEdit: () => void;
  onUpdateAvatar: (imageBase64: string, contentType: string) => void;
}

export const EditAvatar = ({ onCloseEdit, onUpdateAvatar }: EditAvatarProps) => {
  const handleFileChange = (event: any) => {
    const getBase64 = (file: any) => {
      return new Promise(function (resolve, reject) {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => resolve(reader.result);
        reader.onerror = (error) => reject(error);
      });
    };

    const files = event.target.files;
    if (files) {
      const file = files[0];

      getBase64(file).then((data) => {
        onUpdateAvatar(data as string, file.type);
      });
    }
  };

  return (
    <Stack
      direction={"row"}
      gap={3}
      className={styles.center}
      sx={{ justifyContent: "flex-start", width: "100%", mb: 4 }}
    >
      <Typography variant="body2">New Profile: </Typography>
      <input accept="image/*" type="file" onChange={handleFileChange} id="avatar" />
      <Button onClick={onCloseEdit}>
        <CloseIcon sx={{ color: "red" }} />
      </Button>
    </Stack>
  );
};
