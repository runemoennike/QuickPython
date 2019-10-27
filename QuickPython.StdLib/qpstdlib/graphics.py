import pygame

__display_surface = None

def bootstrap_graphics():
	__display_surface = pygame.display.set_mode((640, 480))
	
	pygame.display.update()
	