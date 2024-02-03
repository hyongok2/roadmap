import pygame as pg


class Sound:
    def __init__(self, game) -> None:
        pg.mixer.init()
        self.path = 'resources/sound/'
        self.shotgun = pg.mixer.Sound(self.path + 'shotgun.wav')
