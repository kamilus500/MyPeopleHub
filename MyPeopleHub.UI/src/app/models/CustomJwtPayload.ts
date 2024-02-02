import { JwtPayload } from "jwt-decode";

export interface CustomJwtPayload extends JwtPayload {
    FullName: string;
    UserId: string;
}