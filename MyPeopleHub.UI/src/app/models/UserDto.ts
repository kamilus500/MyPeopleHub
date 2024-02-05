export interface UserDto {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    login: string;
    countOfFriend: number;
    friendIds: string[];
}