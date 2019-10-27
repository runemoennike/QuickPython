from os import environ
environ['PYGAME_HIDE_SUPPORT_PROMPT'] = '1'
import pygame

from .graphics import bootstrap_graphics


def quickpython_bootstrap():
	pygame.init()
	bootstrap_graphics()