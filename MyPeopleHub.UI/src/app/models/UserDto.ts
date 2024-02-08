export interface UserDto {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    login: string;
    fullName: string;
    countOfFriends: number;
    friendIds: string[];
}