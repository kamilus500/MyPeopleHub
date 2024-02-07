export interface UserDto {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    login: string;
    countOfFriends: number;
    friendIds: string[];
}