import { GameState } from "../../Models/Games/States/game-state.enum";

export class GameUpdateStateRequest {
    public id: string;

    public version: number;

    public state: GameState;

    public decoderUserId: string;
}