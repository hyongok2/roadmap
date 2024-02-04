from settings import *
from sys import exit

from game import Game
from score import Score
from preview import Preview
from random import choice


class Main:
    def __init__(self):

        # general setup
        pygame.init()
        self.display_surface = pygame.display.set_mode(
            (WINDOW_WIDTH, WINDOW_HEIGHT))
        self.clock = pygame.time.Clock()
        pygame.display.set_caption('Tetris')

        pygame.mixer.init()
        pygame.mixer.music.load('./sound/music.wav')
        pygame.mixer.music.play(-1, 0.0)
        # shapes
        self.next_shapes = [choice(list(TETROMINOS.keys()))
                            for shape in range(3)]

        # components
        self.score = Score()
        self.game = Game(self.get_next_shape, self.update_score)
        self.preview = Preview()

    def update_score(self, lines, score, level):
        self.score.update_score(lines, score, level)

    def get_next_shape(self):
        next_shape = self.next_shapes.pop(0)
        self.next_shapes.append(choice(list(TETROMINOS.keys())))
        return next_shape

    def run(self):
        while True:

            for event in pygame.event.get():
                if event.type == pygame.QUIT:
                    pygame.quit()
                    exit()

            # display
            self.display_surface.fill(GRAY)

            # components
            self.game.run()
            self.score.run()
            self.preview.run(self.next_shapes)

            # updating the game
            pygame.display.update()
            self.clock.tick()


if __name__ == '__main__':
    main = Main()
    main.run()
