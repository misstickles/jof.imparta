import React from "react";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemText from "@mui/material/ListItemText";
import Divider from "@mui/material/Divider";
import Typography from "@mui/material/Typography";

interface TaskListProps {
  tasks: Task[];
}

export const TaskList = ({ tasks }: TaskListProps) => {
  return tasks.map((t) => {
    return (
      <List sx={{ width: "100%", maxWidth: 360, bgcolor: "background.paper" }} key={t.id}>
        <ListItem alignItems="flex-start" sx={{ borderLeftWidth: "15px", borderLeftColor: "#f00" }}>
          <ListItemText
            primary={t.title}
            secondary={
              <React.Fragment>
                <Typography component="span" variant="body2" sx={{ color: "text.primary", display: "inline" }}>
                  Ali Connors
                </Typography>
                {" — I'll be in your neighborhood doing errands this…"}
              </React.Fragment>
            }
          />
        </ListItem>
        <Divider variant="inset" component="li" />
      </List>
    );
  });
};
