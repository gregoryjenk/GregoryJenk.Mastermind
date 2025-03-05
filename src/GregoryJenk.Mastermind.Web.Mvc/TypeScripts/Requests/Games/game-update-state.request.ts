import { GameState } from "../../Models/Games/States/game-state";

export class GameUpdateStateRequest {
    public id: string;

    public version: number;

    public state: GameState;

    public decoderUserId: string;
}