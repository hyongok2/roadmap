from settings import *
from os.path import join


class Score:
    def __init__(self):
        self.surface = pygame.Surface(
            (SIDEBAR_WIDTH, GAME_HEIGHT * SCORE_HEIGHT_FRACTION - PADDING))
        self.rect = self.surface.get_rect(bottomright=(
            WINDOW_WIDTH - PADDING, WINDOW_HEIGHT - PADDING))
        self.display_surface = pygame.display.get_surface()

        # font
        self.font = pygame.font.Font(
            join('.', 'graphics', 'Russo_One.ttf'), 30)

        # increment
        self.increment_height = self.surface.get_height()/3
        self.display_texts = {'Score': 'Score',
                              'Level': 'Level', 'Lines': 'Lines'}

    def display_text(self, pos, text):
        text_surface = self.font.render(text, True, 'White')
        text_rect = text_surface.get_rect(center=pos)
        self.surface.blit(text_surface, text_rect)

    def update_score(self, lines, score, level):
        self.display_texts['Score'] = 'Score: ' + str(score)
        self.display_texts['Level'] = 'Level: ' + str(level)
        self.display_texts['Lines'] = 'Lines: ' + str(lines)

    def run(self):
        self.surface.fill(GRAY)
        for i, text in enumerate(self.display_texts.values()):
            x = self.surface.get_width() / 2
            y = self.increment_height / 2 + i * self.increment_height
            self.display_text((x, y), text)
        self.display_surface.blit(self.surface, self.rect)
        pygame.draw.rect(self.display_surface, LINE_COLOR, self.rect, 2, 2)
